using Application.Application.Dtos;
using Application.Application.Interfaces.Repositories;
using Application.Domain.Entities;
using Application.Infrastructure.Persistence.Context;
using Microsoft.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Infrastructure.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DefaultDbContext _context;

        public EmployeeRepository(DefaultDbContext context)
        {
            _context = context;
        }

        // ✅ CREATE
        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        // ✅ GET BY ID
        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
        }

        // ✅ GET ALL (with pagination)
        public async Task<List<Employee>> GetAllAsync(int page, int pageSize)
        {
            return await _context.Employees
                .Where(e => !e.IsDeleted)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        // ✅ UPDATE
        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        // ✅ DELETE (Soft Delete ✅ best practice)
        public async Task DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null) return;

            employee.IsDeleted = true;

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
