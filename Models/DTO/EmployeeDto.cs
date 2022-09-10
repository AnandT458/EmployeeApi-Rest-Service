using EmployeeAPI.Models.Domain;

namespace EmployeeAPI.Models.DTO
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }

        public string EmpName { get; set; }

        public double EmpSalary { get; set; }

        public int DeptId { get; set; }

        public DepartmentDto Dept { get; set; }
    }
}
