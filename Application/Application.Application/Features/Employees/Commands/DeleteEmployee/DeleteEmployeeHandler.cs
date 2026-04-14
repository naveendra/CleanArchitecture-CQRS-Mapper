using Application.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Application.Features.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IEmployeeRepository _repository;

        public DeleteEmployeeHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
