using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thucook.Main.API.Middlewares
{
    public class RequestInputLoggingMiddleware
    {
        private readonly string[] _canLogContentTypes =
        {
            "application/json",
            "application/x-www-form-urlencoded"
        };

        private readonly RequestDelegate _next;
        private readonly ILogger<RequestInputLoggingMiddleware> _logger;

        public RequestInputLoggingMiddleware(RequestDelegate next, ILogger<RequestInputLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                context.Request.EnableBuffering();
                using (StreamReader reader = new(context.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    var bodyStr = await reader.ReadToEndAsync();
                    _logger.LogInformation($"REQUEST BODY ({context.Request.ContentType}): \n{bodyStr.Trim()}");
                }
                _logger.LogInformation($"REQUEST HEADERS: \n{string.Join("\n", context.Request.Headers.Select(t => $"{t.Key}: { t.Value}"))}");
                _logger.LogInformation($"REQUEST QUERIES: \n{string.Join("\n", context.Request.Query.Select(t => $"{t.Key}: { t.Value}"))}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when reading request input");
            }
            finally
            {
                context.Request.Body.Position = 0;
                await _next.Invoke(context);
            }
        }
    }
}
