using Application.API.Filters;
using Application.API.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
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

            //ffluentValidation
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<CreateEmployeeDtoValidator>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}
