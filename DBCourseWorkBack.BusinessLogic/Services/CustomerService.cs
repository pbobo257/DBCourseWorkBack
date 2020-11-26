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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            var newCustomer = _customerRepository.Insert(customer);

            await _customerRepository.UnitOfWork.SaveChangesAsync();

            return newCustomer;
        }

        public async Task DeleteCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            _customerRepository.Delete(customer);

            await _customerRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllAsync();
            return customers.ToList();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task<Customer> UpdateCustomerByIdAsync(Customer updateCustomer)
        {
            var customer = await _customerRepository.GetByIdAsync(updateCustomer.Id);

            if (customer == null)
            {
                throw new ItemNotFoundException();
            }

            customer.Name = updateCustomer.Name;
            customer.PhoneNumber = updateCustomer.PhoneNumber;
            customer.BonusCardNumber = updateCustomer.BonusCardNumber;
            customer.Bonuses = updateCustomer.Bonuses;

            _customerRepository.Update(customer);
            await _customerRepository.UnitOfWork.SaveChangesAsync();

            return customer;
        }
    }
}
