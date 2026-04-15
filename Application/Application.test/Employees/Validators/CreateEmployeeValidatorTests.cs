using Application.Application.Features.Employees.Commands.CreateEmployee;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.test.Employee.Validators
{
    public class CreateEmployeeValidatorTests
    {
        private readonly CreateEmployeeValidator _validator;

        public CreateEmployeeValidatorTests()
        {
            _validator = new CreateEmployeeValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var command = new CreateEmployeeCommand("", 123, "Addr", "City", "State");

            var result = _validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(x => x.Name);
        }
        [Fact]
        public void Should_Have_Error_When_EmployeeId_Is_Invalid()
        {
            var command = new CreateEmployeeCommand("John", 0, "Addr", "City", "State");

            var result = _validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(x => x.EmployeeId);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Valid()
        {
            var command = new CreateEmployeeCommand("John", 123, "Addr", "City", "State");

            var result = _validator.TestValidate(command);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
