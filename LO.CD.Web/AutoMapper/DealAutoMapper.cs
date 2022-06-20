using AutoMapper;
using LO.CD.Entities;
using LO.CD.Web.Models.Deals;

namespace LO.CD.Web.AutoMapper
{
    public class DealAutoMapper : Profile
    {
        public DealAutoMapper()
        {
            CreateMap<Deal, DealsListViewModel>();
            CreateMap<DealViewModel, Deal>().ReverseMap();
        }
    }
}
