using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Application.Features.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeValidator() 
        { 
            RuleFor(x => x.Id).NotEmpty().WithMessage("Employee Id is required.");
        }
    }
}
