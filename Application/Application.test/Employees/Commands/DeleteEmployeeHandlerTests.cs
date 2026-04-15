using Application.Application.Features.Employees.Commands.DeleteEmployee;
using Application.Application.Interfaces.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeEntity = Application.Domain.Entities.Employee;


namespace Application.test.Employees.Commands
{
    public class DeleteEmployeeHandlerTests
    {

        private readonly Mock<IEmployeeRepository> _repositoryMock;
        private readonly DeleteEmployeeHandler _handler;

        public DeleteEmployeeHandlerTests()
        {
            _repositoryMock = new Mock<IEmployeeRepository>();
            _handler = new DeleteEmployeeHandler(_repositoryMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Delete_Employee_When_Exists()
        {
            // Arrange
            var employee = new EmployeeEntity
            {
                Id = 1,
                Name = "John"
            };

            _repositoryMock
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(employee);

            // Act
            await _handler.Handle(new DeleteEmployeeCommand(1), CancellationToken.None);

            // Assert
            _repositoryMock.Verify(x => x.DeleteAsync(1), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Throw_When_Employee_NotFound()
        {
            _repositoryMock
                .Setup(x => x.GetByIdAsync(999))
                .ReturnsAsync((EmployeeEntity)null);

            await Assert.ThrowsAsync<KeyNotFoundException>(() =>
                _handler.Handle(new DeleteEmployeeCommand(999), CancellationToken.None)
            );

            _repositoryMock.Verify(x => x.DeleteAsync(It.IsAny<int>()), Times.Never);
        }
    }
}
