using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
            DoctorSchedules = new HashSet<DoctorSchedule>();
        }

        public Guid DoctorId { get; set; }
        public Guid UserId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorCode { get; set; }
        public long DoctorSequence { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public short? YearOfExperience { get; set; }
        public Guid? SpecialityId { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }

        public virtual Speciality Speciality { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<DoctorSchedule> DoctorSchedules { get; set; }
    }
}
