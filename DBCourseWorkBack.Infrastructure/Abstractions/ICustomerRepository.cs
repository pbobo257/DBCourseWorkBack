using DBCourseWorkBack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBCourseWorkBack.Infrastructure.Abstractions
{
    public interface ICustomerRepository : IRepository<Customer, int>
    {
    }
}
