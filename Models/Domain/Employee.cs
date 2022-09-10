using System.ComponentModel.DataAnnotations.Schema;
namespace EmployeeAPI.Models.Domain

{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string EmpName { get; set; }

        public double EmpSalary { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }

        public Department Dept{ get; set; }

    }
}
