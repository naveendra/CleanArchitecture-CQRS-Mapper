using Application.Application.Common.Mappings;
using Application.Application.Features.Employees.Queries.GetAllEmployees;
using Application.Application.Interfaces.Repositories;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeEntity = Application.Domain.Entities.Employee;

namespace Application.test.Employees.Queries
{
    public class GetAllEmployeesHandlerTests
    {
        private readonly Mock<IEmployeeRepository> _repositoryMock;
        private readonly IMapper _mapper;
        private readonly GetAllEmployeesHandler _handler;

        public GetAllEmployeesHandlerTests()
        {
            _repositoryMock = new Mock<IEmployeeRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EmployeeProfile>();
            });

            _mapper = config.CreateMapper();

            _handler = new GetAllEmployeesHandler(
                _repositoryMock.Object,
                _mapper
            );
        }

        [Fact]
        public async Task Handle_Should_Return_List_Of_Employees()
        {
            // Arrange
            var employees = new List<EmployeeEntity>
            {
                new EmployeeEntity { Id = 1, Name = "John", EmployeeId = 123 },
                new EmployeeEntity { Id = 2, Name = "Jane", EmployeeId = 456 }
            };

            _repositoryMock
                .Setup(x => x.GetAllAsync(1, 10))
                .ReturnsAsync(employees);

            // Act
            var result = await _handler.Handle(
                new GetAllEmployeesQuery(1, 10),
                CancellationToken.None
            );

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("John", result[0].Name);
        }

        [Fact]
        public async Task Handle_Should_Return_Empty_List_When_No_Data()
        {
            _repositoryMock
                .Setup(x => x.GetAllAsync(1, 10))
                .ReturnsAsync(new List<EmployeeEntity>());

            var result = await _handler.Handle(
                new GetAllEmployeesQuery(1, 10),
                CancellationToken.None
            );

            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
