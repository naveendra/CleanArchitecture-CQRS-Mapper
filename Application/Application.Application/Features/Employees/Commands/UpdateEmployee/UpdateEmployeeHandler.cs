using Application.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand>
    {

        private readonly IEmployeeRepository _repository;

        public UpdateEmployeeHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetByIdAsync(request.Id);

            if (employee == null) throw new Exception("Not found");

            employee.Name = request.Name;
            employee.EmployeeId = request.EmployeeId;
            employee.Address = request.Address;
            employee.City = request.City;
            employee.State = request.State;

            await _repository.UpdateAsync(employee);

            return Unit.Value;
        }
    }
}
