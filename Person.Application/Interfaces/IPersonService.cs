using Person.Application.Generic.Interfaces;


namespace Person.Application.Interfaces
{
    public interface IPersonService : IBaseCrudService<Domain.Entities.Persons.Person>
    {
    }
}
