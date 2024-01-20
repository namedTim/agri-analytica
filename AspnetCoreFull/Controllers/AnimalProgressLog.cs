using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspnetCoreFull.Data;
using AspnetCoreFull.Models;
using Microsoft.AspNetCore.Authorization;

namespace AspnetCoreFull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnimalProgressLog : ControllerBase
    {
        private readonly AnalyticaContext _context;

        public AnimalProgressLog(AnalyticaContext context)
        {
            _context = context;
        }

        // GET: api/AnimalProgressLog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalProgress>>> GetAnimalProgresses()
        {
          if (_context.AnimalProgresses == null)
          {
              return NotFound();
          }
            return await _context.AnimalProgresses.ToListAsync();
        }

        // GET: api/AnimalProgressLog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalProgress>> GetAnimalProgress(int id)
        {
          if (_context.AnimalProgresses == null)
          {
              return NotFound();
          }
            var animalProgress = await _context.AnimalProgresses.FindAsync(id);

            if (animalProgress == null)
            {
                return NotFound();
            }

            return animalProgress;
        }

        // PUT: api/AnimalProgressLog/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimalProgress(int id, AnimalProgress animalProgress)
        {
            if (id != animalProgress.Id)
            {
                return BadRequest();
            }

            _context.Entry(animalProgress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalProgressExists(id))
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

        // POST: api/AnimalProgressLog
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnimalProgress>> PostAnimalProgress(AnimalProgress animalProgress)
        {
          if (_context.AnimalProgresses == null)
          {
              return Problem("Entity set 'AnalyticaContext.AnimalProgresses'  is null.");
          }
            _context.AnimalProgresses.Add(animalProgress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimalProgress", new { id = animalProgress.Id }, animalProgress);
        }

        // DELETE: api/AnimalProgressLog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalProgress(int id)
        {
            if (_context.AnimalProgresses == null)
            {
                return NotFound();
            }
            var animalProgress = await _context.AnimalProgresses.FindAsync(id);
            if (animalProgress == null)
            {
                return NotFound();
            }

            _context.AnimalProgresses.Remove(animalProgress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalProgressExists(int id)
        {
            return (_context.AnimalProgresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
