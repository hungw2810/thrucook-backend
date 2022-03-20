using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class ResultSheet
    {
        public long ResultSheetId { get; set; }
        public long AppointmentId { get; set; }
        public Guid FormId { get; set; }
        public string Symtom { get; set; }
        public string Result { get; set; }
        public DateTime? ReExaminationDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public Guid? UpdatedByUserId { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual Form Form { get; set; }
    }
}
