using Application.Application.Features.Employees.Queries.GetAllEmployees;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.test.Employees.Validators
{
    public class GetAllEmployeesValidatorTests
    {

        [Fact]
        public void Should_Have_Error_When_Page_Invalid()
        {
            var validator = new GetAllEmployeesValidator();

            var result = validator.TestValidate(new GetAllEmployeesQuery(0, 10));

            result.ShouldHaveValidationErrorFor(x => x.Page);
        }

        [Fact]
        public void Should_Have_Error_When_PageSize_Too_Large()
        {
            var validator = new GetAllEmployeesValidator();

            var result = validator.TestValidate(new GetAllEmployeesQuery(1, 1000));

            result.ShouldHaveValidationErrorFor(x => x.PageSize);
        }
    }
}
