using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class MedicineUnitType
    {
        public MedicineUnitType()
        {
            PrescriptionMedicines = new HashSet<PrescriptionMedicine>();
        }

        public short MedicineUnitTypeId { get; set; }
        public string MedicineUnitTypeName { get; set; }

        public virtual ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }
}
