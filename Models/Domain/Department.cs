using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Models.Domain
{
    public class Department
    {
   
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        [StringLength(18)]

        public string DeptName { get; set; }
    }
}
