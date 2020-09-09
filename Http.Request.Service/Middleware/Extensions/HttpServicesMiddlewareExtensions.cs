using Http.Request.Service.Services;
using Http.Request.Service.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Http.Request.Service.Middleware.Extensions
{
    public static class HttpServicesMiddlewareExtensions
    {
        public static IServiceCollection AddHttpServices(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IHttpService, HttpService>();

            return services;
        }

        public static IApplicationBuilder UseHttpServices(this IApplicationBuilder app) => app.UseMiddleware<HttpServicesMiddleware>();
    }
}
