using EmployeeAPI.Models.Domain;

namespace EmployeeAPI.Repositories
{
    public interface IEmployeeRepository
    {
        //IEnumerable<Employee> GetEmployees();           (synchronous)
        Task<IEnumerable<Employee>> GetEmployeesAsync();   //asynchronous

        Task<Employee> GetEmployeeByIdAsync(int Id);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> DeleteEmployeeAsync(int id);
        Task<Employee> UpdateEmployeeAsync(int ID,Employee employee);

    }
}
