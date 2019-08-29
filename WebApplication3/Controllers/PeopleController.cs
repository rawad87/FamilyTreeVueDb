using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using FamilyTreeVeuDb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FamilyTreeVueDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly SqlConnection _connection;

        public PeopleController(SqlConnection connection)
        {
            _connection = connection;
        }

        // GET: api/People
        [HttpGet]
        public async Task<IEnumerable<Person>> GetPersonAsync()
        {
           var sql = @"INSERT INTO PersonInfo (FirstName, LastName, MiddleName, PlaceOfBirth, DateOfBirth, LifeStatus, FatherId)                         
                            VALUES (@FirstName, @LastName, @MiddleName, @PlaceOfBirth, @DateOfBirth, @LifeStatus, @FatherId)";
            return await _connection.ExecuteAsync(sql, Person);
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = await _connection.Person.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/People/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson([FromRoute] int id, [FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.Id)
            {
                return BadRequest();
            }

            _connection.Entry(person).State = EntityState.Modified;

            try
            {
                await _connection.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/People
        [HttpPost]
        public async Task<IActionResult> PostPerson([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _connection.Person.Add(person);
            await _connection.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = await _connection.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _connection.Person.Remove(person);
            await _connection.SaveChangesAsync();

            return Ok(person);
        }

        private bool PersonExists(int id)
        {
            return _connection.Person.Any(e => e.Id == id);
        }
    }
}