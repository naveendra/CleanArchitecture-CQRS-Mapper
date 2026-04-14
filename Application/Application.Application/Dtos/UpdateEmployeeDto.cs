using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Application.Dtos
{
    public class UpdateEmployeeDto
    {
        
        public string Name { get; set; }

        public int EmployeeId { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
        public string State { get; set; } 

        public DateTime CreatedAt { get; set; }
    }
}
