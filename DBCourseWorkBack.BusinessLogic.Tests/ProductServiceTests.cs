using DBCourseWorkBack.BusinessLogic.Services;
using DBCourseWorkBack.Domain.Exceptions;
using DBCourseWorkBack.Domain.Models;
using DBCourseWorkBack.Infrastructure.Abstractions;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace DBCourseWorkBack.BusinessLogic.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task AddProductAsync_Success_ReturnProduct()
        {
            var product = new Product();

            var productRepositoryMock = new Mock<IProductRepository>();

            productRepositoryMock.Setup(x => x.Insert(It.IsAny<Product>())).Returns(product);
            productRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default));

            var service = new ProductService(productRepositoryMock.Object);

            var result = await service.AddProductAsync(product);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllProducts_Success_ReturnListOfProducts()
        {
            IEnumerable<Product> products = new List<Product>();

            var productRepositoryMock = new Mock<IProductRepository>();

            productRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(products));

            var service = new ProductService(productRepositoryMock.Object);

            var result = await service.GetAllProducts();

            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task GetProductByIdAsync_Success_ReturnProduct()
        {
            var product = new Product();

            var productRepositoryMock = new Mock<IProductRepository>();

            productRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(product));

            var service = new ProductService(productRepositoryMock.Object);

            var result = await service.GetProductByIdAsync(1);

            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task UpdateProductByIdAsync_Success_ReturnProduct()
        {
            var product = new Product();

            var productRepositoryMock = new Mock<IProductRepository>();

            productRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(product));
            productRepositoryMock.Setup(x => x.Update(It.IsAny<Product>()));
            productRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default));

            var service = new ProductService(productRepositoryMock.Object);

            var result = await service.UpdateProductByIdAsync(product);

            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task UpdateProductByIdAsync_ProductNotFound_ThrowsItemNotFoundException()
        {
            var product = new Product();

            var productRepositoryMock = new Mock<IProductRepository>();

            productRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult<Product>(null));
            productRepositoryMock.Setup(x => x.Update(It.IsAny<Product>()));
            productRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default));

            var service = new ProductService(productRepositoryMock.Object);

            await Assert.ThrowsAsync<ItemNotFoundException>(async () => await service.UpdateProductByIdAsync(product));
        }

    }
}
