using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Application.Features.Employees.Commands.UpdateEmployee
{
    public record UpdateEmployeeCommand(
    int Id,
    string Name,
    int EmployeeId,
    string Address,
    string City,
    string State
) : IRequest;
}
