using Microsoft.Extensions.Options;
using Middleware_Sample.Configurations;

namespace Middleware_Sample.CustomMiddlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TechnicalWorkMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TechnicalWorkConfiguration _technicalWorkConfiguration;

        public TechnicalWorkMiddleware(RequestDelegate next, IOptions<TechnicalWorkConfiguration> technicalWorkConfiguration)
        {
            _next = next;
            _technicalWorkConfiguration = technicalWorkConfiguration.Value;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (_technicalWorkConfiguration.IsTechnicalWorkInProgress)
            {
                httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                await httpContext.Response.WriteAsync("Technical work in progress. Access is prohibited.");
                return;
            }

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TechnicalWorkMiddlewareExtensions
    {
        public static IApplicationBuilder UseTechnicalWorkMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TechnicalWorkMiddleware>();
        }
    }
}