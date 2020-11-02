using AutoMapper;
using ContactManager.Models;
using ContactManager.Models.DTO;

namespace Manage.Infrastructure
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Person, PersonDTO>();
        }
    }
}