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
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployeeAsync(EmployeeCreateDTO employeeDto)
        {
            var newEmployee = _mapper.Map<Employee>(employeeDto);
            var createdEmployee = await _employeeService.AddEmployeeAsync(newEmployee);
            return Ok(createdEmployee);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployeeAsync(Employee employeeToUpdate)
        {
            var updatedEmployee = await _employeeService.UpdateEmployeeByIdAsync(employeeToUpdate);
            return Ok(updatedEmployee);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployeeByIdAsync(id);
            return Ok();
        }
    }
}
