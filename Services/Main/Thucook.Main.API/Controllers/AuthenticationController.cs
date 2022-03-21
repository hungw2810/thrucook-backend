using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using Thucook.Main.ApiAction;
using Thucook.Main.ApiModel;
using Thucook.Main.ApiModel.ApiInputModels;
using Thucook.Main.ApiModel.ApiReponseModels;

namespace Thucook.Main.API.Controllers
{
    [AllowAnonymous]
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        public AuthenticationController(IMediator mediator
        ) : base(mediator)
        {
        }
        /// <summary>
        /// Login using phone/email and password
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ApiResponseModel<UserLoginResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Login([FromBody] AuthLoginInputModel input)
        {
            return await _mediator.Send(ApiActionModel.CreateRequest(input));
        }

        /// <summary>
        /// Register location
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register-location")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ApiResponseModel<UserLoginResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RegisterLocation([FromBody] AuthRegisterLocationInputModel input)
        {
            return await _mediator.Send(ApiActionModel.CreateRequest(input));
        }
    }
}