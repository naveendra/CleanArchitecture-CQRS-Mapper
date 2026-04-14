using Application.Application.Dtos;
using MediatR;


namespace Application.Application.Features.Employees.Queries.GetAllEmployees
{
    public record GetAllEmployeesQuery(int Page, int PageSize)
        : IRequest<List<GetEmployeeDto>>;
}
