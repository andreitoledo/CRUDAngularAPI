using System.Collections.Generic;
using System.Threading.Tasks;
using CRUDAPI.Models;
using CRUDAPI.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class PersonController : ControllerBase
    {
        private readonly SqlDbContext _sqlDbContext;

        public PersonController(SqlDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> FindAllPerson(){
            return await _sqlDbContext.Persons.ToListAsync();
        }

        [HttpGet("{personId}")]
        public async Task<ActionResult<Person>> FindPersonById(int personId){
            Person person = await _sqlDbContext.Persons.FindAsync(personId);
            if(person == null) return NotFound();            
            return person;            
        }

        [HttpPost]        
        public async Task<ActionResult<Person>> PersonCreate(Person person){
            await _sqlDbContext.Persons.AddAsync(person);
            await _sqlDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> PersonUpdate(Person person){
            _sqlDbContext.Persons.Update(person);
            await _sqlDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{personId}")]
        public async Task<ActionResult> DeletePerson(int personId){
            Person person = await _sqlDbContext.Persons.FindAsync(personId);
            if(person == null) return NotFound();
            
            _sqlDbContext.Remove(person);
            await _sqlDbContext.SaveChangesAsync();
            return Ok();
        }


    }
}