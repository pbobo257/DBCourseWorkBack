using DBCourseWorkBack.Domain.Models;
using DBCourseWorkBack.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBCourseWorkBack.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
    {
        public override IUnitOfWork UnitOfWork => (AppDbContext)_context;

        public CustomerRepository(AppDbContext context) : base(context)
        {

        }
    }
}
