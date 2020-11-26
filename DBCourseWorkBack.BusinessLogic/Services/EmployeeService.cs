using DBCourseWorkBack.BusinessLogic.Abstractions;
using DBCourseWorkBack.Domain.Exceptions;
using DBCourseWorkBack.Domain.Models;
using DBCourseWorkBack.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DBCourseWorkBack.BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            var newEmployee = _employeeRepository.Insert(employee);

            await _employeeRepository.UnitOfWork.SaveChangesAsync();

            return newEmployee;
        }

        public async Task DeleteEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            _employeeRepository.Delete(employee);

            await _employeeRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return employees.ToList();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task<Employee> UpdateEmployeeByIdAsync(Employee updateEmployee)
        {
            var employee = await _employeeRepository.GetByIdAsync(updateEmployee.Id);

            if(employee == null)
            {
                throw new ItemNotFoundException();
            }

            employee.Name = updateEmployee.Name;
            employee.Position = updateEmployee.Position;
            employee.Salary = updateEmployee.Salary;
            employee.Status = updateEmployee.Status;
            employee.DateOfEmployment = updateEmployee.DateOfEmployment;

            _employeeRepository.Update(employee);
            await _employeeRepository.UnitOfWork.SaveChangesAsync();

            return employee;
        }
    }
}
