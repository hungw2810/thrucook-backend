using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class Location
    {
        public Location()
        {
            Appointments = new HashSet<Appointment>();
            DoctorSchedules = new HashSet<DoctorSchedule>();
            Employees = new HashSet<Employee>();
            Forms = new HashSet<Form>();
            LocationPatients = new HashSet<LocationPatient>();
            Medicines = new HashSet<Medicine>();
            Properties = new HashSet<Property>();
            Specialities = new HashSet<Speciality>();
            Symtoms = new HashSet<Symtom>();
        }

        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public short CityId { get; set; }
        public string Address { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public Guid? UpdatedByUserId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<DoctorSchedule> DoctorSchedules { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Form> Forms { get; set; }
        public virtual ICollection<LocationPatient> LocationPatients { get; set; }
        public virtual ICollection<Medicine> Medicines { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
        public virtual ICollection<Speciality> Specialities { get; set; }
        public virtual ICollection<Symtom> Symtoms { get; set; }
    }
}
