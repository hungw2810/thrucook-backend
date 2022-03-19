using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class User
    {
        public User()
        {
            Doctors = new HashSet<Doctor>();
            Employees = new HashSet<Employee>();
            Patients = new HashSet<Patient>();
        }

        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string PasswordHashed { get; set; }
        public short UserTypeId { get; set; }
        public int? UserStatusId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }

        public virtual UserStatus UserStatus { get; set; }
        public virtual UserType UserType { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
