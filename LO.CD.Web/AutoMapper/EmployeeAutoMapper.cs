using AutoMapper;
using LO.CD.Entities;
using LO.CD.Web.Models.Employees;

namespace LO.CD.Web.AutoMapper
{
    public class EmployeeAutoMapper : Profile
    {
        public EmployeeAutoMapper()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<Employee, EmployeesListViewModel>();
        }
    }
}
