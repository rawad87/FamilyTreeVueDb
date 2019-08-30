using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyTreeVeuDb.Model;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTreeVueDb.Controllers
{
    public interface IPeopleController
    {
        Task<IActionResult> DeletePerson([FromRoute] int id);
        Task<Person> GetPerson([FromRoute] int id);
        Task<IEnumerable<Person>> GetPersonAsync();
        Task<IActionResult> PostPerson([FromBody] Person person);
        Task<IActionResult> PutPerson([FromRoute] int id, [FromBody] Person person);
    }
}