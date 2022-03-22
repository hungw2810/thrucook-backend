using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Thucook.Core;

namespace Thucook.Main.API.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected ICurrentContext _currentContext;

        public BaseController(IMediator mediator, ICurrentContext currentContext)
        {
            _mediator = mediator;
            _currentContext = currentContext;
        }
        protected Guid UserId => _currentContext.UserId.Value;
        protected Guid LocationId => _currentContext.LocationId;
    }
}
