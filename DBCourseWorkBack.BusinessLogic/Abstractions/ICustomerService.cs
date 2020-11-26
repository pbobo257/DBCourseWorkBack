using DBCourseWorkBack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWorkBack.BusinessLogic.Abstractions
{
    public interface ICustomerService
    {
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task DeleteCustomerByIdAsync(int id);
        Task<Customer> UpdateCustomerByIdAsync(Customer updateCustomer);
    }
}
