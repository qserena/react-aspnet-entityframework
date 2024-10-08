﻿using api.Models;
using api.Repositories;
using Microsoft.AspNetCore.Mvc;  

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            _employeeRepository.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (employee == null || id != employee.Id)
            {
                return BadRequest();
            }
            var existingEmployee = _employeeRepository.GetEmployeeById(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            _employeeRepository.UpdateEmployee(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var existingEmployee = _employeeRepository.GetEmployeeById(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            _employeeRepository.DeleteEmployee(id);
            return NoContent();
        }
    }
}

