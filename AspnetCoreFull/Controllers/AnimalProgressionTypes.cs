using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspnetCoreFull.Data;
using AspnetCoreFull.Models;

namespace AspnetCoreFull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalProgressionTypes : ControllerBase
    {
        private readonly AnalyticaContext _context;

        public AnimalProgressionTypes(AnalyticaContext context)
        {
            _context = context;
        }

        // GET: api/AnimalProgressionTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalProgressType>>> GetAnimalProgressTypes()
        {
          if (_context.AnimalProgressTypes == null)
          {
              return NotFound();
          }
            return await _context.AnimalProgressTypes.ToListAsync();
        }

        // GET: api/AnimalProgressionTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalProgressType>> GetAnimalProgressType(int id)
        {
          if (_context.AnimalProgressTypes == null)
          {
              return NotFound();
          }
            var animalProgressType = await _context.AnimalProgressTypes.FindAsync(id);

            if (animalProgressType == null)
            {
                return NotFound();
            }

            return animalProgressType;
        }

        // PUT: api/AnimalProgressionTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimalProgressType(int id, AnimalProgressType animalProgressType)
        {
            if (id != animalProgressType.Id)
            {
                return BadRequest();
            }

            _context.Entry(animalProgressType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalProgressTypeExists(id))
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

        // POST: api/AnimalProgressionTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnimalProgressType>> PostAnimalProgressType(AnimalProgressType animalProgressType)
        {
          if (_context.AnimalProgressTypes == null)
          {
              return Problem("Entity set 'AnalyticaContext.AnimalProgressTypes'  is null.");
          }
            _context.AnimalProgressTypes.Add(animalProgressType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimalProgressType", new { id = animalProgressType.Id }, animalProgressType);
        }

        // DELETE: api/AnimalProgressionTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalProgressType(int id)
        {
            if (_context.AnimalProgressTypes == null)
            {
                return NotFound();
            }
            var animalProgressType = await _context.AnimalProgressTypes.FindAsync(id);
            if (animalProgressType == null)
            {
                return NotFound();
            }

            _context.AnimalProgressTypes.Remove(animalProgressType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalProgressTypeExists(int id)
        {
            return (_context.AnimalProgressTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
