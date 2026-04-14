
using Application.Application.Common.Mappings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


namespace Application.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            // Services
            //services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddAutoMapper(typeof(EmployeeProfile));

            return services;
        }
    }
}
