using EmployeeAPI.Data;
using EmployeeAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext employeeDbContext;
        public EmployeeRepository(EmployeeDbContext _employeeDbContext)  // _ to differentiate between class member and contstructor member
        {
            employeeDbContext = _employeeDbContext;

        }
        //synchronous:
        /*public IEnumerable<Employee> GetEmployees()
        {
            return employeeDbContext.Employees.ToList();
            //throw new NotImplementedException();
        }*/

        //asynchronous:
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {

            return await employeeDbContext.Employees.ToListAsync();
            //throw new NotImplementedException();
        }

        //synchronous:
        /*
        public Employee GetEmployeeById(int Id)
        {
            return employeeDbContext.Employees.Where(x => x.EmployeeId == Id).Single();
        } */

        //asynchronous:
        public async Task< Employee> GetEmployeeByIdAsync(int Id)
        {
            return await employeeDbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == Id);
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            await employeeDbContext.AddAsync(employee);
            await employeeDbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee>DeleteEmployeeAsync(int id)
        {
           var emp =  await employeeDbContext.Employees.SingleAsync(x => x.EmployeeId == id);
            if (emp == null)
            {
                return null;
            }
            else
            {
                employeeDbContext.Employees.Remove(emp);
                await employeeDbContext.SaveChangesAsync();
            }
            return emp;
           
        }

        public async Task<Employee> UpdateEmployeeAsync(int ID, Employee employee)
        {
            var emp = await employeeDbContext.Employees.Where(x => x.EmployeeId == ID).SingleAsync();   

            emp.EmpName = employee.EmpName;

            emp.EmpSalary = employee.EmpSalary;
            emp.DeptId = employee.DeptId;
            employeeDbContext.Employees.Update(emp);
            await employeeDbContext.SaveChangesAsync();           
            return emp;
        }
    }
}
