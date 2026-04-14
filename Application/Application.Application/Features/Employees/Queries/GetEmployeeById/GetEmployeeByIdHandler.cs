using Application.Application.Dtos;
using Application.Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Application.Features.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, GetEmployeeDto>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public GetEmployeeByIdHandler(IEmployeeRepository repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetEmployeeDto> Handle( GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetByIdAsync(request.Id);

            if (employee == null) return null;

            return _mapper.Map<GetEmployeeDto>(employee);
            //return new GetEmployeeDto
            //{
            //    Id = employee.Id,
            //    Name = employee.Name,
            //    EmployeeId = employee.EmployeeId,
            //    Address = employee.Address,
            //    City = employee.City,
            //    State = employee.State,
            //    CreatedDate = employee.CreatedDate
            //};
        }
    }
}    

