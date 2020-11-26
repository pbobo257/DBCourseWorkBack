using DBCourseWorkBack.Domain.Models;
using DBCourseWorkBack.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBCourseWorkBack.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee,int>, IEmployeeRepository
    {
        public override IUnitOfWork UnitOfWork => (AppDbContext)_context;

        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
