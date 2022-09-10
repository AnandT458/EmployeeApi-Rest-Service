using AutoMapper;
using EmployeeAPI.Models.Domain;
using EmployeeAPI.Models.DTO;
using EmployeeAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;
        public EmployeeController(IEmployeeRepository _employeeRepository,IMapper _mapper)
        {
            employeeRepository = _employeeRepository;
            mapper = _mapper;
        }
        /*
        [HttpGet]
        public IActionResult Get()
        {
            //synchronous:   
            //var allEmps = employeeRepository.GetEmployees();
            //return Ok(allEmps);     (Earlier)
            //return employeesDto;    (Now)
            //using DTO classes to expose without Automapper:
            /*var employeesDto = new List<EmployeeDto>();
            allEmps.ToList().ForEach(emp =>
            {
                var empDto = new EmployeeDto()
                {
                    EmployeeId = emp.EmployeeId,
                    EmpName = emp.EmpName,
                    EmpSalary = emp.EmpSalary,
                    DeptId = emp.DeptId,

                };
                employeesDto.Add(empDto);
            });
            return Ok(employeesDto);
            */

        //using DTO classes to expose with Automapper:
        /*var empsDto = mapper.Map<List<EmployeeDto>>(allEmps);
        return Ok(empsDto);
    }*/

        //asynchronous:
        [HttpGet]
        public async Task<IActionResult> GetEmpsAsync()
        {
            var allEmps = await employeeRepository.GetEmployeesAsync();
            var empsDto = mapper.Map<List<EmployeeDto>>(allEmps);
            return Ok(empsDto);
        }

        //synchronous:
        /*
        [HttpGet("Id")]
        public IActionResult GetEmpById(int Id)
        {
            var empById = employeeRepository.GetEmployeeById(Id);
            // var empByIdDto = new EmployeeDto();
            //empByIdDto = empById;
          /*  empById(emp =>
            {
                var empDto = new EmployeeDto()
                {
                    EmployeeId = emp.EmployeeId,
                    EmpName = emp.EmpName,
                    EmpSalary = emp.EmpSalary,
                    DeptId = emp.DeptId,

                };
                
            });
          
            return Ok(empById);
        }*/
        [HttpGet("Id")]
        public async Task<IActionResult> GetEmpByIdAsync(int Id)
        {
            var emp = await employeeRepository.GetEmployeeByIdAsync(Id);
            var empDto = mapper.Map<EmployeeDto>(emp);
            return Ok(empDto);

        }

        [HttpPost]
        public async Task<IActionResult> AddEmpAsync(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var empModel = new Employee()
                {
                    EmpName = emp.EmpName,
                    EmpSalary = emp.EmpSalary,
                    DeptId = emp.DeptId,
                };
                emp = await employeeRepository.AddEmployeeAsync(empModel);
                //optional(to use GET again in Frontend):
                /*
                var empDto = new EmployeeDto()
                {
                    EmpName = emp.EmpName,
                    EmpSalary = emp.EmpSalary,
                    DeptId = emp.DeptId,
                };*/
                var empDto = mapper.Map<EmployeeDto>(emp);
                return Ok(empDto);

            }
        }

        [HttpDelete("empId")]
        public async Task<IActionResult> DeleteEmpAsync(int empId)
        {
            var emp = await employeeRepository.DeleteEmployeeAsync(empId);
            if (emp == null)
                return NotFound();
            else
            {
                var empDto = mapper.Map<EmployeeDto>(emp);
                return Ok(empDto);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmpASync(int ID,Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var emp = await employeeRepository.UpdateEmployeeAsync(ID, employee);
                var empDto = mapper.Map<EmployeeDto>(emp);
                return Ok(empDto);
            }
        }

    }
}
