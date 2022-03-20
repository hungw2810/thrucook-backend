using System;
using Thucook.Commons.Enums;

namespace Thucook.Main.ApiModel.ApiReponseModels
{
    public class UserResponseModel : IApiResponseData
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public UserStatusEnum StatusId { get; set; }
    }
}