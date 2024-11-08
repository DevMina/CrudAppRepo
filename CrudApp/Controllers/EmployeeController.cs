using CrudApp.Application.DTOs;
using CrudApp.Application.Interfaces;
using CrudApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CrudApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employeesDto = await _employeeService.GetAllEmployeesAsync();
            return Ok(employeesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employeeDto = await _employeeService.GetEmployeeByIdAsync(id);
            if (employeeDto == null) return NotFound();
            return Ok(employeeDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDto employeeDto)
        {
            await _employeeService.AddEmployeeAsync(employeeDto);
            return CreatedAtAction(nameof(GetById), new { id = employeeDto.Id }, employeeDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmployeeDto employeeDtoToUpdate)
        {
            var employeeDto = await _employeeService.GetEmployeeByIdAsync(id);
            if (employeeDto == null) return NotFound();

            await _employeeService.UpdateEmployeeAsync(employeeDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}
