
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksApi.Cache;
using ParksApi.Models;

namespace ParksApi.Controllers;

[ApiController, Authorize]
[Route("[controller]")]
public class ParksApiController : ControllerBase
{
    private readonly ParksApiContext _db;
    private readonly ICacheService _cacheService;

    public ParksApiController(ParksApiContext db, ICacheService cacheService)
    {
        _db = db;
        _cacheService = cacheService;
    }

    //GET: api/Parks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)

    {
        var parkCache = new Park();
        var parkCacheList = new List<Park>();
        parkCacheList = _cacheService.GetData<List<Park>>("Park");
        parkCache = parkCacheList.Find(x => x.ParkId == id);
        if (parkCache == null)
        {
            parkCache = await _db.Parks.FindAsync(id);
        }
        return parkCache;
    }
    // api/parks
    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park park)
    {
        _db.Parks.Add(park);
        await _db.SaveChangesAsync();
        _cacheService.RemoveData("Park");
        return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
    }

    [HttpPut("id")]
    public async Task<ActionResult<IEnumerable<Park>>> Put(int id, Park park)

    {
        if (id != park.ParkId)
        {
            return BadRequest();
        }
        _cacheService.RemoveData("Park");
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
    public async Task<ActionResult<IEnumerable<Park>>> DeletePark(int id)
    {
        var park = await _db.Parks.FindAsync(id);
        if (park == null)
        {
            return NotFound();
        }
        _db.Parks.Remove(park);
        _cacheService.RemoveData("Park");
        await _db.SaveChangesAsync();

        return NoContent();
    }
    //api/parks?name=[enterName]&type=[type]&foundedin=[year]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get(string name, string type, int foundedIn)
    {
        var parkCache = new List<Park>();
        parkCache = _cacheService.GetData<List<Park>>("Park");
        if (parkCache == null)
        {
            var park = await _db.Parks.ToListAsync();
            if (park.Count > 0)
            {
                parkCache = park;
                var expirationTime = DateTimeOffset.Now.AddMinutes(3.0);
                _cacheService.SetData("Park", parkCache, expirationTime);
            }

        }
        return parkCache;

        // IQueryable<Park> query = _db.Parks.AsQueryable();

        // if (name != null)
        // {
        //     query = query.Where(entry => entry.Name == name);
        // }
        // if (type != null)
        // {
        //     query = query.Where(entry => entry.Type == type);
        // }
        // if (foundedIn != 0)
        // {
        //     query = query.Where(entry => entry.FoundedIn == foundedIn);
        // }

        // return await query.ToListAsync();
    }

    //api/parks/parkdetail
    [HttpGet]
    [Route("ParkDetail")]
    public async Task<ActionResult<Park>> Get(int id)
    {
        var parkCache = new Park();
        var ParkCacheList = new List<Park>();
        ParkCacheList = _cacheService.GetData<List<Park>>("Park");
        parkCache = ParkCacheList.Find(x => x.ParkId == id);
        if (parkCache == null)
        {
            parkCache = await _db.Parks.FindAsync(id);
        }
        return parkCache;
    }



}
