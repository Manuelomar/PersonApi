using Person.Application.Person.Dtos;
using Person.Application.Person.Handlers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Person.Api.Controllers.Person
{
    [Route("api/[controller]")]
    [ApiController]
    public class Personcontroller : ControllerBase
    {
        private readonly IPersonHandler _personHandler;
        public Personcontroller(IPersonHandler personHandler)
        {
            _personHandler = personHandler;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Entity = await _personHandler.GetById(id);
            if (Entity == null)
            {
                return NotFound();
            }
            return Ok(Entity);
        }
        [HttpGet]
        public async Task<IActionResult> GetPerson(int top = 50)
        {
            try
            {
                var entities = await _personHandler.Get(top);
                return Ok(entities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonDto person)
        {
            try
            {
                var Entity = await _personHandler.Create(person);
                return Ok(Entity);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PersonResponseDto dto)
        {
             try
             {
            var Entity = await _personHandler.Update(id, dto);
            return Ok(Entity);
             }
         catch(Exception ex)
            {
           return BadRequest(ex.Message);
         throw;
        }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>  Delete(int id)
        {
            try
            {

            var Entity = await _personHandler.Delete(id);
            return Ok(Entity);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
    }
}
