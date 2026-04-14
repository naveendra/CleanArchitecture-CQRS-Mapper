using Application.Application.Dtos;
using Application.Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Application.Features.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, List<GetEmployeeDto>>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public GetAllEmployeesHandler(IEmployeeRepository repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetEmployeeDto>> Handle( GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _repository.GetAllAsync(request.Page, request.PageSize);

            if (employees == null) return null;

            return _mapper.Map<List<GetEmployeeDto>>(employees);

            //return employees.Select(e => new GetEmployeeDto
            //{
            //    Id = e.Id,
            //    Name = e.Name,
            //    EmployeeId = e.EmployeeId,
            //    Address = e.Address,
            //    City = e.City,
            //    State = e.State,
            //    CreatedDate = e.CreatedDate
            //}).ToList();
        }
    }
}
