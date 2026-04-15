using Application.Application.Features.Employees.Commands.UpdateEmployee;
using Application.Application.Interfaces.Repositories;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeEntity = Application.Domain.Entities.Employee;

namespace Application.test.Employees.Commands
{
    public class UpdateEmployeeHandlerTests
    {
        private readonly Mock<IEmployeeRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly UpdateEmployeeHandler _handler;

        public UpdateEmployeeHandlerTests()
        {
            _repositoryMock = new Mock<IEmployeeRepository>();
            _mapperMock = new Mock<IMapper>();

            _handler = new UpdateEmployeeHandler(
                _repositoryMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task Handle_Should_Update_Employee_Successfully()
        {
            // Arrange
            var existingEmployee = new EmployeeEntity
            {
                Id = 1,
                Name = "Old Name",
                EmployeeId = 100
            };

            var command = new UpdateEmployeeCommand(
                1,
                "New Name",
                200,
                "Addr",
                "City",
                "State"
            );

            _repositoryMock
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(existingEmployee);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _repositoryMock.Verify(x => x.UpdateAsync(existingEmployee), Times.Once);

            _mapperMock.Verify(m => m.Map(command, existingEmployee), Times.Once);
        }
        [Fact]
        public async Task Handle_Should_Throw_When_Employee_NotFound()
        {
            // Arrange
            var command = new UpdateEmployeeCommand(
                999,
                "Name",
                123,
                "Addr",
                "City",
                "State"
            );

            _repositoryMock
                .Setup(x => x.GetByIdAsync(999))
                .ReturnsAsync((EmployeeEntity)null);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() =>
                _handler.Handle(command, CancellationToken.None)
            );
        }
    }
}
