using Application.Application.Features.Employees.Commands.DeleteEmployee;
using Application.Application.Features.Employees.Queries.GetEmployeeById;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.test.Employees.Validators
{
    public class GetEmployeeByIdValidatorTests
    {
        

        [Fact]
        public void Should_Have_Error_When_Id_Is_Invalid()
        {
            var validator = new GetEmployeeByIdValidator();

            var result = validator.TestValidate(new GetEmployeeByIdQuery(0));

            result.ShouldHaveValidationErrorFor(x => x.Id);
        }
    }
}
