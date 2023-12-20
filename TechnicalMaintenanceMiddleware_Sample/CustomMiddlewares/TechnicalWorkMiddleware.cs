namespace TechnicalMaintenanceMiddleware_Sample.CustomMiddlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TechnicalWorkMiddleware
    {
        private readonly RequestDelegate _next;

        public TechnicalWorkMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
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