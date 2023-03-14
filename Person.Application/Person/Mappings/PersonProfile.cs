using Person.Application.Person.Dtos;
using AutoMapper;

namespace Person.Application.Person.Mappings
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Domain.Entities.Persons.Person, PersonDto>().ReverseMap();
            CreateMap<Domain.Entities.Persons.Person, PersonResponseDto>().ReverseMap();

        }
    }
}
