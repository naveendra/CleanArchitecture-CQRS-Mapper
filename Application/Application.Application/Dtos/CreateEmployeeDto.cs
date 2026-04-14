using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Application.Dtos
{
    public class CreateEmployeeDto
    {
       
        public string Name { get; set; } = string.Empty;
        public int EmployeeId { get; set; }
        public string address { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string state { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
