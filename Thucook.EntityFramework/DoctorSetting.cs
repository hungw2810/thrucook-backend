using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class DoctorSetting
    {
        public Guid DoctorId { get; set; }
        public Guid LocationId { get; set; }
        public short TimePerAppointmentInMinutes { get; set; }
        public short BufferTimePerAppointmentInMinutes { get; set; }
        public int NumberOfAppointmentsPerSlot { get; set; }
        public bool? IsVisibleForBooking { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Location Location { get; set; }
    }
}
