using Application.Application.Dtos;
using FluentValidation;

namespace Application.API.Validators
{
    public class CreateEmployeeDtoValidator : AbstractValidator<CreateEmployeeDto>
    {
        public CreateEmployeeDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required");

            RuleFor(x => x.EmployeeId)
                .NotEmpty().WithMessage("Employee ID is required");

            RuleFor(x => x.address)
                .NotEmpty().WithMessage("Address is required");
        }
    }
}
