using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyTreeVeuDb.Model;
using FamilyTreeVueDb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FamilyTreeVueDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase //, IPeopleController
    {
        private string _connectionString;

        public PeopleController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("FamilyDb");
        }

        // GET: api/People
        [HttpGet]
        public async Task<IEnumerable<Person>> GetWholeTable()
        {
            var personRepository = new PersonRepository(_connectionString);
            return await personRepository.ReadAll();
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<Person> GetPerson([FromRoute] int id)
        {
            var personRepository = new PersonRepository(_connectionString);
            return await personRepository.GetPerson(id);
        }

        [HttpGet(template: "/{id}/{fatherId}")]
        public async Task<IEnumerable<Person>> GetFamilyByFatherId([FromRoute] int id, [FromRoute] int fatherId)
        {
            var personRepository = new PersonRepository(_connectionString);
            return await personRepository.ReadFamily(fatherId, id);
        }


        // POST: api/People/
        [HttpPost]
        public async Task<int> CreatePerson([FromBody] Person person)
        {
            var personRepository = new PersonRepository(_connectionString);
                return await personRepository.Create(person);
        }

        // PATCH api/People/5
        [HttpPatch(template: "{id}")]
        public async Task<int> UpdatePerson([FromBody] Person person)
        {
            var personRepository = new PersonRepository(_connectionString);
            return await personRepository.Update(person);
        }

        // DELETE api/People/5
        [HttpDelete(template: "{id}")]
        public async Task<int> DeletePerson([FromBody] Person person)
        {
            var personRepository = new PersonRepository(_connectionString);
            return await personRepository.Delete(person);
        }

    }
}