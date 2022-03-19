using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class SignupCode
    {
        public int SignupCodeId { get; set; }
        public string SignupCodeVale { get; set; }
        public bool? IsAvaiable { get; set; }
    }
}
