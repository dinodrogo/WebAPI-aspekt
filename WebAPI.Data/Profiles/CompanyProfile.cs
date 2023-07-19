using AutoMapper;
using WebAPI.Data.DTOs;
using WebAPI.Models.Entities;

namespace WebAPI.Data.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile() 
        {
            CreateMap<Company, CompanyDTO>()
                .ReverseMap();
        }
    }
}
