using AutoMapper;
using LO.CD.Entities;
using LO.CD.Web.Models.Branches;

namespace LO.CD.Web.AutoMapper
{
    public class BranchAutoMapper : Profile
    {
        public BranchAutoMapper()
        {
            CreateMap<Branch, BranchViewModel>().ReverseMap();
        }
    }
}
