using AutoMapper;
using WebAPI.Data.DTOs;
using WebAPI.Models.Entities;

namespace WebAPI.Data.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile() 
        {
            CreateMap<Country, CountryDTO>()
                .ReverseMap();
        }
    }
}
