using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class LocationPatient
    {
        public LocationPatient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public Guid LocationPatientId { get; set; }
        public Guid LocationId { get; set; }
        public string LocationPatientCode { get; set; }
        public long LocationPatientSequence { get; set; }
        public Guid? PatientId { get; set; }
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

        public virtual Location Location { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
