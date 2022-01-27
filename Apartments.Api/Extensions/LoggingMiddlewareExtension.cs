using Microsoft.AspNetCore.Builder;

namespace Apartments.Extensions
{
    public static class LoggingMiddlewareExtensions
    {
        public static void UseRequestResponseLogging(this IApplicationBuilder app)
        {
            app.UseMiddleware<LoggingMiddleware>();
        }
    }
}