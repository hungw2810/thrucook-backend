using System;

namespace Thucook.Main.ApiModel.ApiReponseModels
{
    public class UserLoginResponseModel : IApiResponseData
    {
        public AccessTokenModel AccessToken { get; set; }

        public UserResponseModel User { get; set; }
    }

    public class AccessTokenModel
    {
        public string Token { get; set; }

        public DateTime ExpireTime { get; set; }
    }
}
