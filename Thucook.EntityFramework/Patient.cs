using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
            LocationPatients = new HashSet<LocationPatient>();
        }

        public Guid PatientId { get; set; }
        public Guid UserId { get; set; }
        public string PatientCode { get; set; }
        public long PatientSequence { get; set; }
        public bool? IsDefault { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public short Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public short? HeightInCm { get; set; }
        public short? WeightInKg { get; set; }
        public string MedicalHistory { get; set; }
        public string Allergy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public Guid? UpdatedByUserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<LocationPatient> LocationPatients { get; set; }
    }
}
