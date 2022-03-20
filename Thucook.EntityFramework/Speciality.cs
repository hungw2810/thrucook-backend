using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class Speciality
    {
        public Speciality()
        {
            Doctors = new HashSet<Doctor>();
            Symtoms = new HashSet<Symtom>();
        }

        public Guid SpecialityId { get; set; }
        public Guid LocationId { get; set; }
        public string SpecialityName { get; set; }
        public string SpecialtyShortName { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public Guid? UpdatedByUserId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Symtom> Symtoms { get; set; }
    }
}
