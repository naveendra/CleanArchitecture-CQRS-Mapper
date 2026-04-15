using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Application.Features.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdValidator : AbstractValidator<GetEmployeeByIdQuery>
    {
        public GetEmployeeByIdValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Employee Id must be greater than 0.");
        }
    }
}
