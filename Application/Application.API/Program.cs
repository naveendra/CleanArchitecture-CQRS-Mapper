using Application.API.Filters;
using Application.API.Middleware;
using Application.API.Validators;
using Application.Application.Interfaces.Repositories;
using Application.Infrastructure.Persistence.Context;
using Application.Infrastructure.Persistence.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application.Application.DependencyInjection;
using Application.Infrastructure.DependencyInjection;
using Application.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



// Register all services
builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration, builder.Environment)
    .AddApiServices();




var app = builder.Build();

//// Middleware order   Global Exception Handling (FIRST)
//app.UseMiddleware<ExceptionMiddleware>();

//// Environment-based tools
//if (app.Environment.IsDevelopment())
//{
//    //app.MapOpenApi();
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();


app.UseApiMiddleware();

app.Run();
