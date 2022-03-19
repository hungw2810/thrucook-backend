using System.ComponentModel.DataAnnotations;

namespace Thucook.Main.ApiModel.ApiInputModels
{
    public class AuthLoginInputModel : IApiInput
    {
        [Required]
        public string UserName { get; set; }
    }
}
