using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Thucook.EntityFramework;
using Thucook.Main.ApiService.Models;

namespace Thucook.Main.ApiService
{
    public interface IDoctorScheduleService
    {
        /// <summary>
        /// Check if new schedule overlaps with current ones
        /// </summary>
        /// <param name="newSchedule">New schedule</param>
        /// <param name="exSchedules">Current schedules that excluded from database query</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> CheckScheduleHasOverlap(DoctorSchedule newSchedule, DoctorSchedule exSchedule, CancellationToken cancellationToken);

        /// <summary>
        /// Get doctor available slots
        /// </summary>
        /// <param name="ClinicId"></param>
        /// <param name="DoctorId"></param>
        /// <param name="LocationId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<DoctorScheduleSlot>> GetDoctorAvailableTimeSlots(Guid ClinicId, Guid DoctorId, Guid LocationId, CancellationToken cancellationToken);
    }
}
