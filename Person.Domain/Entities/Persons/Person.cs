
namespace Person.Domain.Entities.Persons
{
    public class Person:BaseEntity
    {
        public string Name { get; set; }= string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }

    }
}
