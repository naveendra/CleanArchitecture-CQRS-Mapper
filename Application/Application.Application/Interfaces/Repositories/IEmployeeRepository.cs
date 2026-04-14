using Application.Application.Dtos;
using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Application.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {


            Task AddAsync(Employee employee);
            Task<Employee> GetByIdAsync(int id);
            Task<List<Employee>> GetAllAsync(int page, int pageSize);
            Task UpdateAsync(Employee employee);
            Task DeleteAsync(int id);
        

       

    }
}
