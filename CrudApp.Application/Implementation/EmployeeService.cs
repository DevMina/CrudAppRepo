using CrudApp.Application.Interfaces;
using CrudApp.Core.Entities;
using CrudApp.Core.Interfaces;

namespace CrudApp.Application.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repository;

        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _repository.AddAsync(employee);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _repository.Update(employee);
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
