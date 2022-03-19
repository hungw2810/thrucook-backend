using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class Property
    {
        public Guid PropertyId { get; set; }
        public Guid LocationId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyInternalName { get; set; }
        public short PropertyValueTypeId { get; set; }
        public string PropertyValueTypeDetail { get; set; }
        public bool? IsEditable { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }

        public virtual Location Location { get; set; }
        public virtual PropertyValueType PropertyValueType { get; set; }
    }
}
