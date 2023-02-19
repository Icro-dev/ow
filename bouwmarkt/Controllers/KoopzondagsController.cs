using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bouwmarkt_API.Data;
using bouwmarkt_API.Models;

namespace bouwmarkt_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KoopzondagsController : ControllerBase
    {
        private readonly BouwmarktContext _context;

        public KoopzondagsController(BouwmarktContext context)
        {
            _context = context;
        }

        // GET: api/Koopzondags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Koopzondag>>> GetKoopzondagen()
        {
          if (_context.Koopzondagen == null)
          {
              return NotFound();
          }
            return await _context.Koopzondagen.ToListAsync();
        }

        // GET: api/Koopzondags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Koopzondag>> GetKoopzondag(int id)
        {
          if (_context.Koopzondagen == null)
          {
              return NotFound();
          }
            var koopzondag = await _context.Koopzondagen.FindAsync(id);

            if (koopzondag == null)
            {
                return NotFound();
            }

            return koopzondag;
        }

        // PUT: api/Koopzondags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKoopzondag(int id, Koopzondag koopzondag)
        {
            if (id != koopzondag.Id)
            {
                return BadRequest();
            }

            _context.Entry(koopzondag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KoopzondagExists(id))
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

        // POST: api/Koopzondags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Koopzondag>> PostKoopzondag(Koopzondag koopzondag)
        {
          if (_context.Koopzondagen == null)
          {
              return Problem("Entity set 'BouwmarktContext.Koopzondagen'  is null.");
          }
            _context.Koopzondagen.Add(koopzondag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKoopzondag", new { id = koopzondag.Id }, koopzondag);
        }

        // DELETE: api/Koopzondags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKoopzondag(int id)
        {
            if (_context.Koopzondagen == null)
            {
                return NotFound();
            }
            var koopzondag = await _context.Koopzondagen.FindAsync(id);
            if (koopzondag == null)
            {
                return NotFound();
            }

            _context.Koopzondagen.Remove(koopzondag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KoopzondagExists(int id)
        {
            return (_context.Koopzondagen?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
