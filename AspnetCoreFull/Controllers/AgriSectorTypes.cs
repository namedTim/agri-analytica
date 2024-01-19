using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspnetCoreFull.Data;
using AspnetCoreFull.Filters;
using AspnetCoreFull.Models;

namespace AspnetCoreFull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class AgriSectorTypes : ControllerBase
    {
        private readonly AnalyticaContext _context;

        public AgriSectorTypes(AnalyticaContext context)
        {
            _context = context;
        }

        // GET: api/AgriSectorTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgriSectorType>>> GetAgriSectorTypes()
        {
          if (_context.AgriSectorTypes == null)
          {
              return NotFound();
          }
            return await _context.AgriSectorTypes.ToListAsync();
        }

        // GET: api/AgriSectorTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgriSectorType>> GetAgriSectorType(int id)
        {
          if (_context.AgriSectorTypes == null)
          {
              return NotFound();
          }
            var agriSectorType = await _context.AgriSectorTypes.FindAsync(id);

            if (agriSectorType == null)
            {
                return NotFound();
            }

            return agriSectorType;
        }

        // PUT: api/AgriSectorTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgriSectorType(int id, AgriSectorType agriSectorType)
        {
            if (id != agriSectorType.Id)
            {
                return BadRequest();
            }

            _context.Entry(agriSectorType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgriSectorTypeExists(id))
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

        // POST: api/AgriSectorTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AgriSectorType>> PostAgriSectorType(AgriSectorType agriSectorType)
        {
          if (_context.AgriSectorTypes == null)
          {
              return Problem("Entity set 'AnalyticaContext.AgriSectorTypes'  is null.");
          }
            _context.AgriSectorTypes.Add(agriSectorType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgriSectorType", new { id = agriSectorType.Id }, agriSectorType);
        }

        // DELETE: api/AgriSectorTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgriSectorType(int id)
        {
            if (_context.AgriSectorTypes == null)
            {
                return NotFound();
            }
            var agriSectorType = await _context.AgriSectorTypes.FindAsync(id);
            if (agriSectorType == null)
            {
                return NotFound();
            }

            _context.AgriSectorTypes.Remove(agriSectorType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgriSectorTypeExists(int id)
        {
            return (_context.AgriSectorTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
