using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class UserInformation
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public Guid? UpdatedByUserId { get; set; }
    }
}
