using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApplication1.Models;
using WebApplication1.Models.Helper;
using WebApplication1.Models.PersonalTrainersModels;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalTrainersController : ControllerBase
    {
        private readonly MasterContext _context;

        public PersonalTrainersController(MasterContext context)
        {
            _context = context;
        }

        // GET: api/PersonalTrainers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalTrainers>>> GetPersonalTrainers()
        {
            return await _context.PersonalTrainers.ToListAsync();
        }

        // GET: api/PersonalTrainers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalTrainers>> GetPersonalTrainers(int id)
        {
            var personalTrainers = await _context.PersonalTrainers.FindAsync(id);

            if (personalTrainers == null)
            {
                return NotFound();
            }

            return personalTrainers;
        }

        // PUT: api/PersonalTrainers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalTrainers(int id, PersonalTrainers personalTrainers)
        {
            if (id != personalTrainers.Id)
            {
                return BadRequest();
            }

            _context.Entry(personalTrainers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalTrainersExists(id))
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

        // POST: api/PersonalTrainers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PersonalTrainers>> PostPersonalTrainers(CreatePersonalTrainer input)
        {
            try
            {
                var converter = new SerializerGenerator();
                var output = new PersonalTrainers();
                var result = converter.SerializeObject(ref input, ref output);
                _context.PersonalTrainers.Add(result);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPersonalTrainers", new { id = result.Id });
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
            
        }

        // DELETE: api/PersonalTrainers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonalTrainers>> DeletePersonalTrainers(int id)
        {
            var personalTrainers = await _context.PersonalTrainers.FindAsync(id);
            if (personalTrainers == null)
            {
                return NotFound();
            }

            _context.PersonalTrainers.Remove(personalTrainers);
            await _context.SaveChangesAsync();

            return personalTrainers;
        }

        private bool PersonalTrainersExists(int id)
        {
            return _context.PersonalTrainers.Any(e => e.Id == id);
        }
    }
}
