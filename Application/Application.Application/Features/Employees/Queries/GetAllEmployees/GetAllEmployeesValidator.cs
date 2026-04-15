using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Application.Features.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesValidator : AbstractValidator<GetAllEmployeesQuery>
    {
        public GetAllEmployeesValidator() 
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page number must be greater than 0.");

            RuleFor(x => x.PageSize)
                .GreaterThan(0)
                .LessThanOrEqualTo(100)
                .WithMessage("Page size must be between 1 and 100.");   
        }
    }
}
