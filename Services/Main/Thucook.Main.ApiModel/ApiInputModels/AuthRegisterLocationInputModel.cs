using Thucook.Commons.Enums;
using System.ComponentModel.DataAnnotations;

namespace Thucook.Main.ApiModel.ApiInputModels
{
    public class AuthRegisterLocationInputModel : IApiInput
    {
        [Required]
        [StringLength(256, MinimumLength = 3)]
        public string BussinessName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(128, MinimumLength = 3)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(128, MinimumLength = 3)]
        public string PhoneNumber { get;    set; }

        [Required]
        public CityEnum City { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 3)]
        public string Address { get; set; }

        [Required]
        [StringLength(8)]
        public string SignUpCode { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
