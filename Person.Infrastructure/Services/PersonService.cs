using Person.Application.Interfaces;
using Person.Domain.Entities;
using Person.Infrastructure.Context;
using AutoMapper;

namespace Person.Infrastructure.Services
{
    public class PersonService : BaseCrudService<Domain.Entities.Persons.Person>, IPersonService
    {
        public PersonService(IAgendaDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
