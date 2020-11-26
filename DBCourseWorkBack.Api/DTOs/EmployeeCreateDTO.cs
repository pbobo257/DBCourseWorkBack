using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBCourseWorkBack.Api.DTOs
{
    public class EmployeeCreateDTO
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public string Status { get; set; }
    }
}
