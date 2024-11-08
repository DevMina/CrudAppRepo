using CrudApp.Application.DTOs;
using CrudApp.Application.Interfaces;
using CrudApp.Core.Entities;
using CrudApp.Core.Interfaces;
using System.Collections.Generic;

namespace CrudApp.Application.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repository;

        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }
        private EmployeeDto MapFromModelToDto(Employee employee)
        {
            var employeeDto = new EmployeeDto()
            {
                Id = employee.Id,
                Address = employee.Address,
                Email = employee.Email,
                Mobile = employee.Mobile,
                Name = employee.Name,
            };
            return employeeDto;
        }
        private Employee MapFromDtoToModel(EmployeeDto employeeDto)
        {
            var employee = new Employee()
            {
                Id = employeeDto.Id,
                Address = employeeDto.Address,
                Email = employeeDto.Email,
                Mobile = employeeDto.Mobile,
                Name = employeeDto.Name,
            };
            return employee;
        }
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            List<EmployeeDto> employeesDto;
            IEnumerable<Employee> employees = await _repository.GetAllAsync();
            employeesDto = new List<EmployeeDto>();
            foreach (Employee employee in employees) {
                employeesDto.Add(MapFromModelToDto(employee));
            }
            return employeesDto;
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            return MapFromModelToDto(await _repository.GetByIdAsync(id));
        }

        public async Task AddEmployeeAsync(EmployeeDto employeeDto)
        {
            await _repository.AddAsync(MapFromDtoToModel(employeeDto));
        }

        public async Task UpdateEmployeeAsync(EmployeeDto employeeDto)
        {
            _repository.Update(MapFromDtoToModel(employeeDto));
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee != null)
            {
                _repository.Delete(employee);
            }
        }
    }
}
