using System.Diagnostics;
using System.Net;

namespace API.Middleware
{
    public class RequestTimeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public RequestTimeMiddleware(RequestDelegate next,ILogger<RequestTimeMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Stopwatch sw = Stopwatch.StartNew();
            await _next.Invoke(context);
            sw.Stop();
            long responseTime = sw.ElapsedMilliseconds;
            Console.WriteLine($"Время запроса {responseTime}");
            if (responseTime > 500)
            {
                _logger.LogWarning($"Долгий запрос ({responseTime})");               
                return ;
            }
        }
    }
}
