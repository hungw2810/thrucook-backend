using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class SignupCode
    {
        public int SignupCodeId { get; set; }
        public string SignupCodeValue { get; set; }
        public bool? IsAvaiable { get; set; }
    }
}
