using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bouwmarkt_API.Data;
using bouwmarkt_API.Models;
using System.Diagnostics;
using bouwmarkt_API.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace bouwmarkt_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VestigingsController : ControllerBase
{
    private readonly IVestigingRepository _vestingingRepository;

    public VestigingsController(IVestigingRepository vestigingRepository)
    {
        _vestingingRepository = vestigingRepository;
    }

    // GET: api/Vestigings
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vestiging>>> GetVestigingen()
    {
        if (ModelState.IsValid)
        {
            try
            {
                return await _vestingingRepository.GetVestigingen();
            }
            catch (Exception ex)
            {
                var Vestigingen = await _vestingingRepository.GetVestigingen();
                var VestString = Vestigingen.ToString();


                if (VestString.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(ex);
                }
            }
        }
        else
        {
            return BadRequest(ModelState);

        }
    }

    // GET: api/Vestigings/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Vestiging>> GetVestiging(int id)
    {
        if (ModelState.IsValid)
        {
            if (_vestingingRepository.VestigingExists(id))
            {
                try
                {
                    return await _vestingingRepository.GetVestiging(id);
                }
                catch (Exception ex)
                {
                        return BadRequest(ex); 
                }
            }
            else
            {
                return Problem("Een vestiging met het ingevoerde vestigingsnummer bestaat niet");
            }
        }
        else
        {
            return BadRequest(ModelState);

        }
    }

    // PUT: api/Vestigings/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVestiging(int id, Vestiging vestiging)
    {
        if (ModelState.IsValid)
        {
            if (_vestingingRepository.VestigingExists(id))
            {
                try
                {
                    _vestingingRepository.PutVestiging(vestiging);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
            else
            {
                return Problem("Een vestiging met het ingevoerde vestigingsnummer bestaat niet");
            }
        }
        else
        {
            return BadRequest(ModelState);
        }
    }

    // POST: api/Vestigings
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Vestiging>> PostVestiging(Vestiging vestiging)
    {

        if (ModelState.IsValid)
        {
            try
            {
                _vestingingRepository.PostVestiging(vestiging);
                return CreatedAtAction("GetVestiging", new { id = vestiging.Vestigingsnummer }, vestiging);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        else
        {
            return BadRequest(ModelState);
        }
    }

    // DELETE: api/Vestigings/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVestiging(int id)
    {

        if (ModelState.IsValid)
        {
            if (_vestingingRepository.VestigingExists(id))
            {
                try
                {
                    var getVestiging = await _vestingingRepository.FindVestigingById(id);
                    _vestingingRepository.DeleteVestiging(getVestiging);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
            else
            {
                return Problem("Een vestiging met het ingevoerde vestigingsnummer bestaat niet");
            }
        }
        else
        {
            return BadRequest(ModelState);
        }
    }
}

