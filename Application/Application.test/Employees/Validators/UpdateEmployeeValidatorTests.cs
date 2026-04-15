using Application.Application.Features.Employees.Commands.CreateEmployee;
using Application.Application.Features.Employees.Commands.UpdateEmployee;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.test.Employees.Validators
{
    public class UpdateEmployeeValidatorTests
    {
        private readonly UpdateEmployeeValidator _validator = new();


        [Fact]
        public void Should_Have_Error_When_Id_Is_Invalid()
        {
            var command = new UpdateEmployeeCommand(0, "Name", 123, "Addr", "City", "State");

            var result = _validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var command = new UpdateEmployeeCommand(1, "", 123, "Addr", "City", "State");

            var result = _validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Valid()
        {
            var command = new UpdateEmployeeCommand(1, "John", 123, "Addr", "City", "State");

            var result = _validator.TestValidate(command);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
