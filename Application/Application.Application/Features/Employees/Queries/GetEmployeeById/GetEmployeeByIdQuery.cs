using Application.Application.Dtos;
using Application.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Application.Features.Employees.Queries.GetEmployeeById
{
    public record GetEmployeeByIdQuery(int Id)
     : IRequest<GetEmployeeDto>;
}
