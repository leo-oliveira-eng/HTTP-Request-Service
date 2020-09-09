using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Http.Request.Service.Middleware
{
    public class HttpServicesMiddleware
    {
        readonly RequestDelegate _next;

        public HttpServicesMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.Any(d => d.Key.Equals("RequestCode")))
                context.Request.Headers.Add("RequestCode", $"{Guid.NewGuid()}");

            await _next.Invoke(context);
        }
    }
}
