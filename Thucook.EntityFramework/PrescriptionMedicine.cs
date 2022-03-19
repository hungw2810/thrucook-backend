using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class PrescriptionMedicine
    {
        public long PrescriptionMedicineId { get; set; }
        public long PrescriptionId { get; set; }
        public long MedicineId { get; set; }
        public string MedicineName { get; set; }
        public float Amount { get; set; }
        public short MedicineUnitTypeId { get; set; }
        public string Guide { get; set; }

        public virtual Medicine Medicine { get; set; }
        public virtual MedicineUnitType MedicineUnitType { get; set; }
        public virtual Prescription Prescription { get; set; }
    }
}
