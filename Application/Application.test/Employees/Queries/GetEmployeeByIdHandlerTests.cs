using Application.Application.Common.Mappings;
using Application.Application.Features.Employees.Queries.GetEmployeeById;
using Application.Application.Interfaces.Repositories;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeEntity = Application.Domain.Entities.Employee;

namespace Application.test.Employees.Queries
{
    public class GetEmployeeByIdHandlerTests
    {
        private readonly Mock<IEmployeeRepository> _repositoryMock;
        private readonly IMapper _mapper;
        private readonly GetEmployeeByIdHandler _handler;

        public GetEmployeeByIdHandlerTests()
        {
            _repositoryMock = new Mock<IEmployeeRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EmployeeProfile>();
            });

            _mapper = config.CreateMapper();

            _handler = new GetEmployeeByIdHandler(
                _repositoryMock.Object,
                _mapper
            );
        }

        [Fact]
        public async Task Handle_Should_Return_EmployeeDto_When_Found()
        {
            // Arrange
            var employee = new EmployeeEntity
            {
                Id = 1,
                Name = "John",
                EmployeeId = 123,
                Address = "Addr",
                City = "Colombo",
                State = "Western"
            };

            _repositoryMock
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(employee);

            // Act
            var result = await _handler.Handle(
                new GetEmployeeByIdQuery(1),
                CancellationToken.None
            );

            // Assert
            Assert.NotNull(result);
            Assert.Equal("John", result.Name);
            Assert.Equal(123, result.EmployeeId);
        }

        [Fact]
        public async Task Handle_Should_Return_Null_When_NotFound()
        {
            _repositoryMock
                .Setup(x => x.GetByIdAsync(999))
                .ReturnsAsync((EmployeeEntity)null);

            var result = await _handler.Handle(
                new GetEmployeeByIdQuery(999),
                CancellationToken.None
            );

            Assert.Null(result);
        }
    }
}
