using MediatR;

namespace Application.Application.Features.Employees.Commands.CreateEmployee
{
    public record CreateEmployeeCommand(
     string Name,
     int EmployeeId,
     string Address,
     string City,
     string State
 ) : IRequest;
}
