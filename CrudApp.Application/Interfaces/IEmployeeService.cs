using CrudApp.Application.DTOs;
using CrudApp.Core.Entities;

namespace CrudApp.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(EmployeeDto employee);
        Task UpdateEmployeeAsync(EmployeeDto employee);
        Task DeleteEmployeeAsync(int id);
    }
}
