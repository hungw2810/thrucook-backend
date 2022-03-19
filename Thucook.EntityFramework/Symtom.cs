using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class Symtom
    {
        public Guid SymtomId { get; set; }
        public Guid LocationId { get; set; }
        public string SymtomName { get; set; }
        public string Content { get; set; }
        public Guid? SpecialityId { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Speciality Speciality { get; set; }
    }
}
