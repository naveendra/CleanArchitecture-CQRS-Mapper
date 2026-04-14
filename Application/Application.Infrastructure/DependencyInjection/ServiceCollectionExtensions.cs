using Application.Application.Interfaces.Caching;
using Application.Application.Interfaces.Repositories;
using Application.Infrastructure.Caching.Hybrid;
using Application.Infrastructure.Caching.Memory;
using Application.Infrastructure.Caching.Redis;
using Application.Infrastructure.Persistence.Context;
using Application.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Application.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment env)
        {
            // Database
            services.AddDbContext<DefaultDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //  Logging 
            services.AddLogging();

            // Memory Cache
            services.AddMemoryCache();

            // Repositories
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();



            if (env.IsDevelopment()) 
            {
                //Memory Cache Service
                services.AddScoped<ICacheService, MemoryCacheService>();
            }
            else 
            {
                // 🔴 PROD → Redis >>hybrid

                services.AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = configuration.GetConnectionString("RedisConnection");
                });

                services.AddScoped<RedisCacheService>();

                services.AddScoped<ICacheService>(sp =>
                {
                    var memory = sp.GetRequiredService<IMemoryCache>();
                    var redis = sp.GetRequiredService<RedisCacheService>();

                    return new HybridCacheService(memory, redis);
                });


                // 🔴 PROD → Redis

                //services.AddStackExchangeRedisCache(options =>
                //{
                //    options.Configuration = configuration.GetConnectionString("RedisConnection");
                //});

                //services.AddSingleton<IConnectionMultiplexer>(sp =>
                //{
                //    var config = ConfigurationOptions.Parse(
                //        configuration.GetConnectionString("RedisConnection"), true);

                //    config.AbortOnConnectFail = false;

                //    return ConnectionMultiplexer.Connect(config);
                //});

                //services.AddScoped<ICacheService, RedisCacheService>();
            }




            return services;
        }
    }
}
