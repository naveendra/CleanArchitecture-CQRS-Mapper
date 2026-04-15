using Application.API.Filters;
using Microsoft.AspNetCore.Mvc;
namespace Application.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            // Add Filters
            services.AddControllers(options =>
            {
                options.Filters.Add<ApiResponseFilter>();
            });

            // Swagger/OpenAPI configuration
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}
