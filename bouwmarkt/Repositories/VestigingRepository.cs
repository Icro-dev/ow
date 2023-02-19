using bouwmarkt_API.Data;
using bouwmarkt_API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using bouwmarkt_API.Controllers;

namespace bouwmarkt_API.Repositories;

    public class VestigingRepository : IVestigingRepository
    {
        private readonly BouwmarktContext _context;

        public VestigingRepository(BouwmarktContext context)
        {
            _context = context;
        }

    public async Task<ActionResult<IEnumerable<Vestiging>>> GetVestigingen()
    {
        return await _context.Vestigingen.ToListAsync();
    }

    public async Task<ActionResult<Vestiging>> GetVestiging(int id)
    {
        var vestiging = await _context.Vestigingen.FindAsync(id);

        return vestiging;
    }

    public void PutVestiging(Vestiging vestiging)
    {
        _context.Entry(vestiging).State = EntityState.Modified;
        _context.SaveChangesAsync();
        
    }

    public void PostVestiging(Vestiging vestiging)
    {
        _context.Vestigingen.Add(vestiging);
        _context.SaveChangesAsync();
    }

    public Task<Vestiging?> FindVestigingById(int id)
    {
        return _context.Vestigingen.FirstOrDefaultAsync(v => v.Vestigingsnummer == id);
    }

    public void DeleteVestiging(Vestiging vestiging)
    {
            _context.Vestigingen.Remove(vestiging);
            _context.SaveChangesAsync();
    }

    public bool VestigingExists(int id)
    {
        return (_context.Vestigingen?.Any(e => e.Vestigingsnummer == id)).GetValueOrDefault();
    }
}

