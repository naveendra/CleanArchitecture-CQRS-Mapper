using Application.Application.Features.Employees.Commands.DeleteEmployee;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.test.Employees.Validators
{
    public class DeleteEmployeeValidatorTests
    {
        private readonly DeleteEmployeeValidator _validator = new();

        [Fact]
        public void Should_Have_Error_When_Id_Is_Invalid()
        {
            var command = new DeleteEmployeeCommand(0);

            var result = _validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Valid()
        {
            var command = new DeleteEmployeeCommand(1);

            var result = _validator.TestValidate(command);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
