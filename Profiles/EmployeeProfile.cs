using AutoMapper;
using EmployeeAPI.Models.Domain;
using EmployeeAPI.Models.DTO;

namespace EmployeeAPI.Profiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();    //also add automapper in Program.cs
        }
    }
}
