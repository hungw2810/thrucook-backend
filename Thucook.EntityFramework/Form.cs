using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class Form
    {
        public Form()
        {
            ResultSheets = new HashSet<ResultSheet>();
        }

        public Guid FormId { get; set; }
        public Guid LocationId { get; set; }
        public string FormName { get; set; }
        public bool? IsEditable { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public Guid? UpdatedByUserId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<ResultSheet> ResultSheets { get; set; }
    }
}
