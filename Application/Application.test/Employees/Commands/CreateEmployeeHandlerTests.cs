using Application.Application.Features.Employees.Commands.CreateEmployee;
using Application.Application.Interfaces.Repositories;
using EmployeeEntity = Application.Domain.Entities.Employee;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Xunit;

namespace Application.test.Employee.Commands
{
    public class CreateEmployeeHandlerTests
    {

        private readonly Mock<IEmployeeRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CreateEmployeeHandler _handler;
        

        public CreateEmployeeHandlerTests()
        {
            _repositoryMock = new Mock<IEmployeeRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new CreateEmployeeHandler(
                _repositoryMock.Object, 
                _mapperMock.Object);

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
            _mapperMock
               .Setup(m => m.Map<EmployeeEntity>(It.IsAny<CreateEmployeeCommand>()))
               .Returns(new EmployeeEntity
               {
                   Name = "John",
                   EmployeeId = 123
               });

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _repositoryMock.Verify(x =>
                x.AddAsync(It.Is<EmployeeEntity>(e =>
                    e.Name == "John" &&
                    e.EmployeeId == 123
                )),
                Times.Once);
        }
    }
}
