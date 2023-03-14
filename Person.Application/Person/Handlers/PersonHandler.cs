using Person.Application.Generic.Handlers;
using Person.Application.Generic.Interfaces;
using Person.Application.Interfaces;
using Person.Application.Person.Dtos;
using Person.Domain.Entities.Persons;
using AutoMapper;

namespace Person.Application.Person.Handlers
{
    public interface IPersonHandler : IBaseCrudHandler<PersonResponseDto,PersonDto, Domain.Entities.Persons.Person>
    {
        new Task<PersonDto> GetById(int id);
        new Task<List<Domain.Entities.Persons.Person>> Get(int top = 50); new Task<PersonDto> Update(PersonResponseDto dto);
        new Task<PersonDto> Update(int id, PersonResponseDto dto);
        new Task<PersonResponseDto> Create(PersonDto dto);
    }

    public class PersonHandler : BaseCrudHandler<PersonResponseDto,PersonDto, Domain.Entities.Persons.Person>, IPersonHandler
    {
        public PersonHandler(IPersonService crudService, IMapper mapper) : base(crudService, mapper)
        {
        }


        public new async Task<PersonDto> GetById(int id)
        {
            return await base.GetById(id);
        }
        public new async Task<List<Domain.Entities.Persons.Person>> Get(int top = 50)
        {
            return await base.Get(top);
        }

        public new async Task<PersonDto> Update(PersonResponseDto dto)
        {
            return await base.Update(dto);
        }

        public new async Task<PersonDto> Update(int id, PersonResponseDto dto)
        {
            return await base.Update(id, dto);
        }

        public new async Task<PersonResponseDto> Create(PersonDto dto)
        {
            return await base.Create(dto);
        }

      
    }
}
