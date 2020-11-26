using AutoMapper;
using DBCourseWorkBack.Api.DTOs;
using DBCourseWorkBack.BusinessLogic.Abstractions;
using DBCourseWorkBack.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBCourseWorkBack.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomerAsync(CustomerCreateDTO customerDto)
        {
            var newCustomer = _mapper.Map<Customer>(customerDto);
            var createdCustomer = await _customerService.AddCustomerAsync(newCustomer);
            return Ok(createdCustomer);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomerAsync(Customer customerToUpdate)
        {
            var updatedCustomer = await _customerService.UpdateCustomerByIdAsync(customerToUpdate);
            return Ok(updatedCustomer);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomerByIdAsync(id);
            return Ok();
        }
    }
}
