using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFHype.Models;
using System.Linq;
using System;


namespace SFHype.Controllers
{
  [Route("api/Shops")]
  [ApiController]

  public class SFHypeController : ControllerBase
  {
    private readonly ShopContext _db;
    public SFHypeController(ShopContext db)
    {
      _db = db;       
    }
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Shop>>> Get(string type)
    {
      var query = _db.Shops.AsQueryable();
      if (type != null)
      {
        query = query.Where(e => e.Type == type);
      }

      return await query.ToListAsync();
    }
    //GET: api/Shops/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Shop>> GetMessage(int id)
    {
      var shop = await _db.Shops.FindAsync(id);

      if (shop == null)
      {
        return NotFound();
      }
      shop.Hype += .003f;
      _db.Entry(shop).State = EntityState.Modified;
      await _db.SaveChangesAsync();

      return shop;
    }

    // POST api/Shops
    [HttpPost]
    public async Task<ActionResult<Shop>> Post(Shop shop)
    {
      var thisShop = _db.Shops.FirstOrDefault(entry => entry.Name == shop.Name);
      
      if (thisShop == null)
      {
        
        _db.Shops.Add(shop);
        shop.Originated = DateTime.Now;
        shop.LastAccess = DateTime.Now;
        shop.Hype = 0.25f;
        // _db.Shops.Update(thisShop);    
        await _db.SaveChangesAsync();
      }
      else
      {
        return BadRequest();
      }
      return CreatedAtAction("Post", new { id = shop.ShopId}, shop);
    }

    // PUT: api/Messages/1  }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Shop shop)
    {
      if (id != shop.ShopId)
      {
        return BadRequest();
      }
      _db.Entry(shop).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }

      catch (DbUpdateConcurrencyException)
      {
        if(!ShopExists(id))
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
    
    // DELETE: api/Messages/1  }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShop(int id)
    {
      var shop = await _db.Shops.FindAsync(id);
      if (shop == null)
      {
        return NotFound();
      }

      _db.Shops.Remove(shop);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    private bool ShopExists(int id)
    {
      return _db.Shops.Any(e => e.ShopId == id);
    }
  }
}