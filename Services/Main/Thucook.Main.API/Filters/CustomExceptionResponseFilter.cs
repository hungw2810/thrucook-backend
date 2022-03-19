using Thucook.Main.ApiModel;
using Thucook.Main.ApiModel.ApiErrorMessages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace Thucook.Main.API.Filters
{
    public class CustomExceptionResponseFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _env;

        public CustomExceptionResponseFilter(ILoggerFactory loggerFactory, IWebHostEnvironment env)
        {
            _logger = loggerFactory.CreateLogger<CustomExceptionResponseFilter>();
            _env = env;
        }
        public override void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            if (context.Exception is OperationCanceledException)
            {
                _logger.LogWarning("Request has been cancelled by user");
                context.Result = ApiResponse.CreateModel(HttpStatusCode.Gone);
            }
            else
            {
                _logger.LogError(context.Exception, "Internal server error");
                context.Result = ApiResponse.CreateErrorModel(HttpStatusCode.InternalServerError,
                    _env.EnvironmentName == "Production"
                    ? ApiSystemErrorMessages.INTERNAL_SERVER_ERROR.Format("")
                    : ApiSystemErrorMessages.INTERNAL_SERVER_ERROR.Format($"\nMessage: {context.Exception.Message}\nStackTrace: {context.Exception.StackTrace}"));
            }
        }
    }
}
