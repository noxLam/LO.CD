using AutoMapper;
using LO.CD.Entities;
using LO.CD.Web.Models.Cars;

namespace LO.CD.Web.AutoMapper
{
    public class CarAutoMapperProfile : Profile
    {
        public CarAutoMapperProfile()
        {
            CreateMap<Car, CarsListViewModel>();
            CreateMap<CarViewModel, Car>().ReverseMap();
        }
    }
}
