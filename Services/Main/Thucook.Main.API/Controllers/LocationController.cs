using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using Thucook.Core;
using Thucook.Main.ApiAction;
using Thucook.Main.ApiModel.ApiInputModels;
using Thucook.Main.ApiModel.ApiReponseModels;

namespace Thucook.Main.API.Controllers
{
    [Authorize]
    [Route("location")]
    [ApiController]
    public class LocationController : BaseController
    {
        public LocationController(IMediator mediator,
            ICurrentContext currentContext
        ) : base(mediator, currentContext)
        {
        }

        /// <summary>
        /// Get location informations with specialities and doctors
        /// </summary>
        [HttpGet]
        [Route("info")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(LocationInfoResponseModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetInfomation()
        {
            return await _mediator.Send(ApiActionModel.CreateRequest(UserId, LocationId, new LocationGetInfoInputModel()));
        }
    }
}
