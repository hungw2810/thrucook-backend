using Thucook.Main.ApiModel;
using Thucook.Main.ApiModel.ApiErrorMessages;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net;

namespace Thucook.Main.API.Filters
{
    public class ValidateModelFilter : ActionFilterAttribute
    {
        private readonly ILogger _logger;

        public ValidateModelFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ValidateModelFilter>();
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errorMessages = string.Join("\n", context.ModelState.Select(t => string.Join("\n", t.Value.Errors.Select(e => e.ErrorMessage))));
                _logger.LogWarning($"Model state invalid\n{errorMessages}");
                context.Result = ApiResponse.CreateErrorModel(HttpStatusCode.BadRequest,
                    ApiSystemErrorMessages.MODEL_VALIDATION_FAILED.Format($"\n{errorMessages}"));
            }
        }
    }
}
