using Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Infrastructure.Persistence.Context
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
