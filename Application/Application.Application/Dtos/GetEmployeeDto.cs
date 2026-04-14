using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Application.Dtos
{
    public class GetEmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int EmployeeId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
