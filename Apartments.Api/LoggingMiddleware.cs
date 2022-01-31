using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Apartments
{
    public class LoggingMiddleware
    {
        private static readonly string LogPath = $@"{Directory.GetCurrentDirectory()}/log.txt";

        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<LoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                string log = $"{DateTime.Now} Request {context.Request.Method} {context.Request.Path.Value} => {context.Response.StatusCode}";

                await using StreamWriter sw = File.AppendText(LogPath);
                await sw.WriteLineAsync(log);

                _logger.LogInformation(log);
            }
        }
    }
}