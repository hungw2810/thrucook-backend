using System;

namespace Thucook.Main.ApiModel.ApiReponseModels
{
    public class LocationInfoResponseModel : IApiResponseData
    {
        public Guid LocationId { get; set; }

        public string LocationName { get; set; }
    }
}
