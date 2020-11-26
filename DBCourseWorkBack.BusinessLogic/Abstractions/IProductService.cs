using DBCourseWorkBack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWorkBack.BusinessLogic.Abstractions
{
    public interface IProductService
    {
        Task<Product> AddProductAsync(Product product);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductByIdAsync(int id);
        Task DeleteProductByIdAsync(int id);
        Task<Product> UpdateProductByIdAsync(Product updateProduct);
    }
}
