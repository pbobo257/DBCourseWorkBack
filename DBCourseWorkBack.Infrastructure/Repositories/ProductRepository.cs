using DBCourseWorkBack.Domain.Models;
using DBCourseWorkBack.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWorkBack.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product, int>, IProductRepository
    {
        public override IUnitOfWork UnitOfWork => (AppDbContext)_context;

        public ProductRepository(AppDbContext context):base(context)
        {
        }
    }
}
