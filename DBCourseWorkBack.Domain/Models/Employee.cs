using DBCourseWorkBack.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBCourseWorkBack.Domain.Models
{
    public class Employee : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public string Status { get; set; }
    }
}
