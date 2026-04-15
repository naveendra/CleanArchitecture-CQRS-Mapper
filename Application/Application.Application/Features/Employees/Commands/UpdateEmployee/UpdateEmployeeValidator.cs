using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;


namespace Application.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.EmployeeId)
                .GreaterThan(0);

            RuleFor(x => x.Address)
                .NotEmpty();

            RuleFor(x => x.City)
                .NotEmpty();

            RuleFor(x => x.State)
                .NotEmpty();
        }
    }
}
