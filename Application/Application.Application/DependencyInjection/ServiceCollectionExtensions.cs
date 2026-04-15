
using Application.Application.Common.Behaviors;
using Application.Application.Common.Mappings;
using Application.Application.Features.Employees.Commands.CreateEmployee;
using FluentValidation;
using MediatR;
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
            // MediatR
            services.AddMediatR(cfg =>
                 cfg.RegisterServicesFromAssembly(typeof(CreateEmployeeHandler).Assembly));

            // FluentValidation
            services.AddValidatorsFromAssembly(typeof(CreateEmployeeValidator).Assembly);

            // Pipeline
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
