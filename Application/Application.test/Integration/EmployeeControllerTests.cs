using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace Application.test.Integration
{
    public class EmployeeControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public EmployeeControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateEmployee_Should_Return_OK()
        {
            var request = new
            {
                name = "John",
                employeeId = 123,
                address = "Colombo",
                city = "Colombo",
                state = "Western"
            };

            var response = await _client.PostAsJsonAsync("/api/employee/create", request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetEmployeeById_Should_Return_Employee()
        {
            // First create
            var createRequest = new
            {
                name = "John",
                employeeId = 123,
                address = "Colombo",
                city = "Colombo",
                state = "Western"
            };

            await _client.PostAsJsonAsync("/api/employee/create", createRequest);

            // Then fetch
            var response = await _client.GetAsync("/api/employee/getbyid/1");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var data = await response.Content.ReadAsStringAsync();

            Assert.Contains("John", data);
        }

        [Fact]
        public async Task GetAllEmployees_Should_Return_List()
        {
            var response = await _client.GetAsync("/api/employee/getall?page=1&pageSize=10");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreateEmployee_Should_Return_BadRequest_When_Invalid()
        {
            var request = new
            {
                name = "", // invalid
                employeeId = 0
            };

            var response = await _client.PostAsJsonAsync("/api/employee/create", request);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }
}
