using AutoMapper;
using LO.CD.Entities;
using LO.CD.Web.Models.Customers;

namespace LO.CD.Web.AutoMapper
{
    public class CustomerAutoMapper : Profile
    {
        public CustomerAutoMapper()
        {
            CreateMap<Customer, CustomerListViewModel>();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Customer, CustomerDetailsViewModel>();
        }
    }
}
