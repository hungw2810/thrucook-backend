using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class PropertyValueType
    {
        public PropertyValueType()
        {
            Properties = new HashSet<Property>();
        }

        public short PropertyValueTypeId { get; set; }
        public string PropertyValueName { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}
