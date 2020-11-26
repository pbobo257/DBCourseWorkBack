using DBCourseWorkBack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBCourseWorkBack.Infrastructure.Abstractions
{
    public interface IEmployeeRepository : IRepository<Employee, int>
    {
    }
}
