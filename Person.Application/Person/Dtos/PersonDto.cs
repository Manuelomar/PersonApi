using Person.Application.Generic.Dtos;

namespace Person.Application.Person.Dtos
{
    public class PersonDto 
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}
