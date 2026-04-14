using Application.Application.Dtos;
using Application.Application.Features.Employees.Commands.CreateEmployee;
using Application.Application.Features.Employees.Commands.DeleteEmployee;
using Application.Application.Features.Employees.Commands.UpdateEmployee;
using Application.Application.Features.Employees.Queries.GetAllEmployees;
using Application.Application.Features.Employees.Queries.GetEmployeeById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            var employees = await _mediator.Send(new GetAllEmployeesQuery(page, pageSize));
            return Ok(employees);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee =await _mediator.Send( new GetEmployeeByIdQuery(id));
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateEmployeeCommand command)
        {
            await _mediator.Send(command);

            return Ok();
            

        }

        [HttpPut]
        [Route("Update/{id}")]
        public  async Task<IActionResult> Update(int id, UpdateEmployeeCommand command)
        {
            await  _mediator.Send(command with { Id = id } );
           
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteEmployeeCommand(id));
            return Ok();
        }
    }
}