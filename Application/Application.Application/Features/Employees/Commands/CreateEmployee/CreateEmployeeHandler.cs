using MediatR;
using Application.Application.Interfaces.Repositories;
using Application.Domain.Entities;


namespace Application.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand>
    {
        private readonly IEmployeeRepository _repository;

        public CreateEmployeeHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Name = request.Name,
                EmployeeId = request.EmployeeId,
                Address = request.Address,
                City = request.City,
                State = request.State,
                CreatedDate = DateTime.Now
            };

            await _repository.AddAsync(employee);

            return Unit.Value;
        }
    }
}
