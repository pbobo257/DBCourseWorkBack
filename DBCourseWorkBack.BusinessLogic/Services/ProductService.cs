using DBCourseWorkBack.BusinessLogic.Abstractions;
using DBCourseWorkBack.Domain.Exceptions;
using DBCourseWorkBack.Domain.Models;
using DBCourseWorkBack.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWorkBack.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            var newProduct = _productRepository.Insert(product);

            await _productRepository.UnitOfWork.SaveChangesAsync();

            return newProduct;
        }

        public async Task DeleteProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            
            _productRepository.Delete(product);

            await _productRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            return products.ToList();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<Product> UpdateProductByIdAsync(Product updateProduct)
        {
            var product = await _productRepository.GetByIdAsync(updateProduct.Id);

            if (product == null)
            {
                throw new ItemNotFoundException();
            }

            product.Manufacturer = updateProduct.Manufacturer;
            product.Name = updateProduct.Name;
            product.Weight = updateProduct.Weight;
            product.Amount = updateProduct.Amount;
            product.Article = updateProduct.Article;
            product.Price = updateProduct.Price;

            _productRepository.Update(product);
            await _productRepository.UnitOfWork.SaveChangesAsync();

            return product;
        }
    }
}
