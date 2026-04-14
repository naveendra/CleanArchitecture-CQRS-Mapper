using Application.Application.Dtos;
using Application.Application.Features.Employees.Commands.CreateEmployee;
using Application.Application.Features.Employees.Commands.UpdateEmployee;
using Application.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Application.Common.Mappings
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            // Entity → DTO
            CreateMap<Employee, GetEmployeeDto>();

            // Command → Entity
            CreateMap<CreateEmployeeCommand, Employee>();

            // Update Command → Entity
            CreateMap<UpdateEmployeeCommand, Employee>();
        }
    }
}
