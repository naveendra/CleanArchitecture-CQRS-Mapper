using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Application.Features.Employees.Commands.DeleteEmployee
{
    public record DeleteEmployeeCommand(int Id) : IRequest;
   
}
