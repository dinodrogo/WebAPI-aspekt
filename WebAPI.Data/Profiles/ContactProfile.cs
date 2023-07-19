using AutoMapper;
using WebAPI.Data.DTOs;
using WebAPI.Models.Entities;

namespace WebAPI.Data.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile() 
        {
            CreateMap<Contact, ContactDTO>()
                .ReverseMap();
        }
    }
}
