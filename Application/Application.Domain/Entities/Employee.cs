using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int EmployeeId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
