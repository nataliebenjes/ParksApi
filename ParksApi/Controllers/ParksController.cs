using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ParkApi.Models;

namespace Parks.Controllers;

[ApiController]
[Route("[controller]")]
public class ParksController : ControllerBase
{
    private readonly ParkApiContext _db;
    public ParksController(ParkApiContext db)
    {
        _db = db;
    }
    //GET: api/Parks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
        Park park = await _db.Parks.FindAsync(id);

        if (park == null)
        {
            return NotFound();
        }
        return park;
    }
    // api/parks
    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park park)
    {
        _db.Parks.Add(park);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
    }
    [HttpPut("id")]
    public async Task<IActionResult> Put(int id, Park park)
    {
        if (id != park.ParkId)
        {
            return BadRequest();
        }
        _db.Parks.Update(park);

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ParkExists(id))
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
    private bool ParkExists(int id)
    {
        return _db.Parks.Any(e => e.ParkId == id);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
        Park park = await _db.Parks.FindAsync(id);
        if (park == null)
        {
            return NotFound();
        }
        _db.Parks.Remove(park);
        await _db.SaveChangesAsync();

        return NoContent();
    }
    //api/parks?name=[enterName]&type=[type]&foundedin=[year]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get(string name, string type, int foundedIn)
    {
        IQueryable<Park> query = _db.Parks.AsQueryable();

        if (name != null)
        {
            query = query.Where(entry => entry.Name == name);
        }
        if (type != null)
        {
            query = query.Where(entry => entry.Type == type);
        }
        if (foundedIn != 0)
        {
            query = query.Where(entry => entry.FoundedIn == foundedIn);
        }

        return await query.ToListAsync();
    }


}
