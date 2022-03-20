using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class Employee
    {
        public long EmployeeId { get; set; }
        public Guid UserId { get; set; }
        public Guid LocationId { get; set; }
        public short RoleId { get; set; }
        public bool? IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public Guid? UpdatedByUserId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
