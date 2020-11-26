using DBCourseWorkBack.BusinessLogic.Services;
using DBCourseWorkBack.Domain.Exceptions;
using DBCourseWorkBack.Domain.Models;
using DBCourseWorkBack.Infrastructure.Abstractions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DBCourseWorkBack.BusinessLogic.Tests
{
    public class CustomerServiceTests
    {
        [Fact]
        public async Task AddCustomerAsync_Success_ReturnCustomer()
        {
            var customer = new Customer();

            var customerRepositoryMock = new Mock<ICustomerRepository>();

            customerRepositoryMock.Setup(x => x.Insert(It.IsAny<Customer>())).Returns(customer);
            customerRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default));

            var service = new CustomerService(customerRepositoryMock.Object);

            var result = await service.AddCustomerAsync(customer);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllCustomers_Success_ReturnListOfCustomers()
        {
            IEnumerable<Customer> customers = new List<Customer>();

            var customerRepositoryMock = new Mock<ICustomerRepository>();

            customerRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(customers));

            var service = new CustomerService(customerRepositoryMock.Object);

            var result = await service.GetAllCustomers();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetCustomerByIdAsync_Success_ReturnCustomer()
        {
            var customer = new Customer();

            var customerRepositoryMock = new Mock<ICustomerRepository>();

            customerRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(customer));

            var service = new CustomerService(customerRepositoryMock.Object);

            var result = await service.GetCustomerByIdAsync(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task UpdateCustomerByIdAsync_Success_ReturnCustomer()
        {
            var customer = new Customer();

            var customerRepositoryMock = new Mock<ICustomerRepository>();

            customerRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(customer));
            customerRepositoryMock.Setup(x => x.Update(It.IsAny<Customer>()));
            customerRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default));

            var service = new CustomerService(customerRepositoryMock.Object);

            var result = await service.UpdateCustomerByIdAsync(customer);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task UpdateCustomerByIdAsync_CustomerNotFound_ThrowsItemNotFoundException()
        {
            var customer = new Customer();

            var customerRepositoryMock = new Mock<ICustomerRepository>();

            customerRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult<Customer>(null));
            customerRepositoryMock.Setup(x => x.Update(It.IsAny<Customer>()));
            customerRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default));

            var service = new CustomerService(customerRepositoryMock.Object);

            await Assert.ThrowsAsync<ItemNotFoundException>(async () => await service.UpdateCustomerByIdAsync(customer));
        }
    }
}
