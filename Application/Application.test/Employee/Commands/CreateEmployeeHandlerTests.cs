using Application.Application.Features.Employees.Commands.CreateEmployee;
using Application.Application.Interfaces.Repositories;
using Application.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.test.Employee.Commands
{
    public class CreateEmployeeHandlerTests
    {
        private readonly Mock<IEmployeeRepository> _repositoryMock;
        private readonly CreateEmployeeHandler _handler;

        public CreateEmployeeHandlerTests()
        {
            _repositoryMock = new Mock<IEmployeeRepository>();
            _handler = new CreateEmployeeHandler(_repositoryMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Create_Employee_Successfully()
        {
            // Arrange
            var command = new CreateEmployeeCommand(
                "John",
                123,
                "Colombo",
                "Colombo",
                "Western"
            );

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _repositoryMock.Verify(x =>
                x.AddAsync(It.Is<Employee>(e =>
                    e.Name == "John" &&
                    e.EmployeeId == 123
                )),
                Times.Once);
        }
    }
}
