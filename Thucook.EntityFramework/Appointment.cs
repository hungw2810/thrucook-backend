using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class Appointment
    {
        public Appointment()
        {
            Prescriptions = new HashSet<Prescription>();
            ResultSheets = new HashSet<ResultSheet>();
        }

        public long AppointmentId { get; set; }
        public Guid? PatientId { get; set; }
        public Guid LocationPatientId { get; set; }
        public Guid LocationId { get; set; }
        public Guid DoctorId { get; set; }
        public long ScheduleId { get; set; }
        public DateTime StartDatetime { get; set; }
        public DateTime? ActualCheckInDatetime { get; set; }
        public DateTime? ActualStartDatetime { get; set; }
        public DateTime? ActualFinishDatetime { get; set; }
        public short AppointmentStatusId { get; set; }
        public string Symtom { get; set; }
        public string CancelReason { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Location Location { get; set; }
        public virtual LocationPatient LocationPatient { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual DoctorSchedule Schedule { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
        public virtual ICollection<ResultSheet> ResultSheets { get; set; }
    }
}
