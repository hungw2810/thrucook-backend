using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class Prescription
    {
        public Prescription()
        {
            PrescriptionMedicines = new HashSet<PrescriptionMedicine>();
        }

        public long PrescriptionId { get; set; }
        public long AppointmentId { get; set; }
        public string Note { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }
}
