using DBCourseWorkBack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWorkBack.BusinessLogic.Abstractions
{
    public interface IEmployeeService
    {
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task DeleteEmployeeByIdAsync(int id);
        Task<Employee> UpdateEmployeeByIdAsync(Employee updateEmployee);
    }
}
