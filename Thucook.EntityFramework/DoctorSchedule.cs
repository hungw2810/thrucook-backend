using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class DoctorSchedule
    {
        public DoctorSchedule()
        {
            Appointments = new HashSet<Appointment>();
        }

        public long ScheduleId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid LocationId { get; set; }
        public DateTime StartDatetime { get; set; }
        public DateTime EndDatetime { get; set; }
        public string RecurrenceString { get; set; }
        public DateTime? ScheduleUntil { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public Guid? UpdatedByUserId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
