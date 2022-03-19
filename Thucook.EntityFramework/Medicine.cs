using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class Medicine
    {
        public Medicine()
        {
            PrescriptionMedicines = new HashSet<PrescriptionMedicine>();
        }

        public long MedicineId { get; set; }
        public Guid? LocationId { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsEditable { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }
}
