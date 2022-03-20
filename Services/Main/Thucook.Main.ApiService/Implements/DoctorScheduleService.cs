using Thucook.Commons.Enums;
using Thucook.Commons.Extensions;
using Thucook.Commons.Utils;
using Thucook.EntityFramework;
using Thucook.Main.ApiService.Models;
using Ical.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Thucook.Main.ApiService;

namespace ThuCook.Main.ApiService.Implements
{
    public class DoctorScheduleService : IDoctorScheduleService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DoctorScheduleService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task<bool> CheckScheduleHasOverlap(DoctorSchedule newSchedule, DoctorSchedule exSchedule, CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ThucookContext>();
                //Create iCal event
                var newEvent = CalendarHelper.FromString(newSchedule.RecurrenceString, newSchedule.StartDatetime, newSchedule.EndDatetime);
                var newOccurrences = newEvent.GetOccurrences(newSchedule.StartDatetime, newSchedule.StartDatetime.AddYears(1));

                // Get current schedules to compare
                // IMPORTANT: should not filter by location because 1 doctor cannot work in more than one location at same time
                var calendar = new Ical.Net.Calendar();
                var currentSchedules = await (from d in dbContext.DoctorSchedules
                                              where
                                              d.DoctorId == newSchedule.DoctorId &&
                                              d.LocationId == newSchedule.LocationId &&
                                              (newSchedule.ScheduleId == 0 || d.ScheduleId != newSchedule.ScheduleId) &&
                                              (exSchedule == null || exSchedule.ScheduleId == 0 || d.ScheduleId != exSchedule.ScheduleId) &&
                                              (!newSchedule.ScheduleUntil.HasValue || d.StartDatetime <= newSchedule.ScheduleUntil) &&
                                              (!d.ScheduleUntil.HasValue || d.ScheduleUntil >= newSchedule.StartDatetime)
                                              select d)
                                              .ToListAsync(cancellationToken);
                foreach (var schedule in currentSchedules)
                {
                    var evt = CalendarHelper.FromString(schedule.RecurrenceString, schedule.StartDatetime, schedule.EndDatetime);
                    calendar.Events.Add(evt);
                }

                if (exSchedule != null && exSchedule.IsDeleted == false)
                {
                    var xevt = CalendarHelper.FromString(exSchedule.RecurrenceString, exSchedule.StartDatetime, exSchedule.EndDatetime);
                    calendar.Events.Add(xevt);
                }

                // Check overlap
                var nOccurrences = newOccurrences
                    .Select(o => new
                    {
                        start = o.Period.StartTime.AsUtc,
                        end = o.Period.EndTime.AsUtc
                    })
                    .ToArray();
                var cOccurrences = calendar.GetOccurrences(newSchedule.StartDatetime, newSchedule.ScheduleUntil ?? newSchedule.StartDatetime.AddYears(1))
                    .Select(o => new
                    {
                        start = o.Period.StartTime.AsUtc,
                        end = o.Period.EndTime.AsUtc
                    })
                    .ToArray();
                foreach (var n in nOccurrences)
                {
                    foreach (var o in cOccurrences)
                    {
                        if (CalendarHelper.HasOverLap(n.start, n.end, o.start, o.end))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }

        }

        public async Task<List<DoctorScheduleSlot>> GetDoctorAvailableTimeSlots(Guid ClinicId, Guid DoctorId, Guid LocationId, CancellationToken cancellationToken)
        {
            //using var scope = _scopeFactory.CreateScope();
            //{
            //    var _dbContext = scope.ServiceProvider.GetRequiredService<ThucookContext>();
            //    var clinic = await (from c in _dbContext.Locations.AsNoTracking()
            //                        where c.LocationId == ClinicId
            //                        select new
            //                        {
            //                            c.LocationId,
            //                            c.AllowBookingInDays
            //                        }).FirstOrDefaultAsync(cancellationToken);

            //    var doctor = await (from d in _dbContext.Doctors.AsNoTracking()
            //                        join s in _dbContext.DoctorSettings.AsNoTracking() on d.DoctorId equals s.DoctorId
            //                        where
            //                            d.DoctorId == DoctorId &&
            //                            d.ClinicId == ClinicId &&
            //                            d.IsEnabled.Value
            //                        select new
            //                        {
            //                            d.DoctorId,
            //                            s.TimePerAppointmentInMinutes,
            //                            s.BufferTimePerAppointmentInMinutes,
            //                            s.NumberOfAppointmentsPerSlot
            //                        }).FirstOrDefaultAsync(cancellationToken);

            //    // TODO: hard code time zone at GMT+7
            //    var utcStartTime = DateTime.UtcNow;
            //    DateTime userStartTime = utcStartTime.ToDateTimeFromUtc();
            //    var userEndTime = userStartTime.AddDays(clinic.AllowBookingInDays).Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            //    var utcEndTime = userEndTime.ToUniversalTime();

            //    Log.Debug($"User Starttime: {userStartTime}");
            //    Log.Debug($"User Endtime: {userEndTime}");

            //    // Get schedule and occurrences
            //    var schedules = await (from d in _dbContext.DoctorSchedules
            //                           where
            //                           d.DoctorId == DoctorId &&
            //                           d.ClinicId == ClinicId &&
            //                           d.LocationId == LocationId &&
            //                           (d.StartDatetime <= utcEndTime) &&
            //                           (!d.ScheduleUntil.HasValue || d.ScheduleUntil >= utcStartTime)
            //                           select d)
            //                            .ToListAsync(cancellationToken);

            //    Log.Debug($"Schedules count: {schedules.Count}");

            //    List<dynamic> occurrences = new();
            //    foreach (var schedule in schedules)
            //    {
            //        var evt = CalendarHelper.FromString(schedule.RecurrenceString, schedule.StartDatetime, schedule.EndDatetime);
            //        var occs = evt.GetOccurrences(utcStartTime, utcEndTime)
            //            .Select(o => new
            //            {
            //                ScheduleId = schedule.ScheduleId,
            //                Start = o.Period.StartTime.AsUtc,
            //                End = o.Period.EndTime.AsUtc
            //            })
            //            .ToArray();
            //        Log.Debug($"Schedule ID: {schedule.ScheduleId}");
            //        Log.Debug($"Recurence string: {schedule.RecurrenceString}");
            //        occurrences.AddRange(occs);
            //    }
            //    Log.Debug($"Occurences: {occurrences.Count}");

            //    var appointments = await (
            //        from a in _dbContext.Appointments.AsNoTracking()
            //        where
            //        a.DoctorId == DoctorId &&
            //        a.ClinicId == ClinicId &&
            //        a.LocationId == LocationId &&
            //        a.StartDatetime >= utcStartTime && a.StartDatetime <= utcEndTime &&
            //        a.AppointmentStatusId < (short)AppointmentStatusEnum.Canceled
            //        group a by new { a.ClinicId, a.LocationId, a.DoctorId, a.StartDatetime } into grp
            //        select new
            //        {
            //            grp.Key.StartDatetime,
            //            AppointmentCount = grp.Count()
            //        })
            //        .Distinct()
            //        .ToListAsync(cancellationToken);
            //    var appointmentTimes = appointments.Select(a => a.StartDatetime.ToUnixTime())
            //                            .Distinct()
            //                            .ToHashSet();
            //    // Calculate blocks
            //    List<DoctorScheduleSlot> output = new();
            //    foreach (var occurrence in occurrences)
            //    {
            //        List<long> slots = new();
            //        DateTime timeIdx = occurrence.Start;
            //        while (timeIdx < occurrence.End)
            //        {
            //            var appointmentCount = appointments.Find(a => a.StartDatetime == timeIdx)?.AppointmentCount ?? 0;
            //            if (appointmentCount < doctor.NumberOfAppointmentsPerSlot)
            //            {
            //                slots.Add(timeIdx.ToUnixTime());
            //            }
            //            timeIdx = timeIdx.AddMinutes(doctor.TimePerAppointmentInMinutes + doctor.BufferTimePerAppointmentInMinutes);
            //        }

            //        if (slots.Count > 0)
            //        {
            //            output.Add(new DoctorScheduleSlot
            //            {
            //                ScheduleId = occurrence.ScheduleId,
            //                OccurrenceStartUnix = DateTimeExtensions.ToUnixTime(occurrence.Start),
            //                Slots = slots.ToArray()
            //            });
            //        }
            //    }

            //    return output;
            //}
            return null;
        }
    }
}
