using System.ComponentModel.DataAnnotations;

namespace Thucook.Main.ApiModel.ApiInputModels
{
    public class AuthLoginInputModel : IApiInput
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
