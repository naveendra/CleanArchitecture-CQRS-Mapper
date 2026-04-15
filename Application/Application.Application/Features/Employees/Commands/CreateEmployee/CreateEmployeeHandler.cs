using MediatR;
using Application.Application.Interfaces.Repositories;
using Application.Domain.Entities;
using AutoMapper;


namespace Application.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public CreateEmployeeHandler(IEmployeeRepository repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee =  _mapper.Map<Employee>(request);
            //var employee = new Employee
            //{
            //    Name = request.Name,
            //    EmployeeId = request.EmployeeId,
            //    Address = request.Address,
            //    City = request.City,
            //    State = request.State,
            //    CreatedDate = DateTime.Now
            //};

            await _repository.AddAsync(employee);

            
        }
    }
}
