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
    public class EmployeeServiceTests
    {
        [Fact]
        public async Task AddEmployeeAsync_Success_ReturnEmployee()
        {
            var employee = new Employee();

            var employeeRepositoryMock = new Mock<IEmployeeRepository>();

            employeeRepositoryMock.Setup(x => x.Insert(It.IsAny<Employee>())).Returns(employee);
            employeeRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default));

            var service = new EmployeeService(employeeRepositoryMock.Object);

            var result = await service.AddEmployeeAsync(employee);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllEmployees_Success_ReturnListOfEmployees()
        {
            IEnumerable<Employee> employees = new List<Employee>();

            var employeeRepositoryMock = new Mock<IEmployeeRepository>();

            employeeRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(employees));

            var service = new EmployeeService(employeeRepositoryMock.Object);

            var result = await service.GetAllEmployees();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetEmployeeByIdAsync_Success_ReturnEmployee()
        {
            var employee = new Employee();

            var employeeRepositoryMock = new Mock<IEmployeeRepository>();

            employeeRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(employee));

            var service = new EmployeeService(employeeRepositoryMock.Object);

            var result = await service.GetEmployeeByIdAsync(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task UpdateEmployeeByIdAsync_Success_ReturnEmployee()
        {
            var employee = new Employee();

            var employeeRepositoryMock = new Mock<IEmployeeRepository>();

            employeeRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(employee));
            employeeRepositoryMock.Setup(x => x.Update(It.IsAny<Employee>()));
            employeeRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default));

            var service = new EmployeeService(employeeRepositoryMock.Object);

            var result = await service.UpdateEmployeeByIdAsync(employee);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task UpdateEmployeeByIdAsync_EmployeeNotFound_ThrowsItemNotFoundException()
        {
            var employee = new Employee();

            var employeeRepositoryMock = new Mock<IEmployeeRepository>();

            employeeRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult<Employee>(null));
            employeeRepositoryMock.Setup(x => x.Update(It.IsAny<Employee>()));
            employeeRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default));

            var service = new EmployeeService(employeeRepositoryMock.Object);

            await Assert.ThrowsAsync<ItemNotFoundException>(async () => await service.UpdateEmployeeByIdAsync(employee));
        }
    }
}
