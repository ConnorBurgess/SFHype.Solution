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

        /// <summary>
        /// Retrieve complete listing of all Shops
        /// </summary>
        /// <remarks> <b>Get</b> all Shops</remarks>
        /// <param name="type" example="restaurant">Specifies type of business to retrieve <b>Not currently implemented </b></param>
        /// <param name="ranked" example="true">Returns list of shops sorted descending by hype rating</param>
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Shop>>> GetAll(string type, bool ranked)
        {
            var query = _db.Shops.Include(entry => entry.Remarks).AsQueryable();
            // if (type != null)
            // {
            //     query = query.Where(e => e.Type == type);
            // }
            if (ranked == true)
            {
                var queryList = await query.ToListAsync();
                List<Shop> querySorted = queryList.OrderByDescending(shop => shop.Hype).ToList();
                return querySorted;
            }
            else
            {
                return await query.ToListAsync();
            }
        }
        //GET: api/Shops/1
        /// <summary>
        /// Retrieve details of a specific shop
        /// </summary>
        /// <remarks><b>Get</b> specific shop details</remarks>
        /// <param name="id" example="1"> ShopId is required to retrieve specific shop</param>
        [HttpGet("{id}")]
        public async Task<ActionResult<Shop>> GetById(int id)
        {
            var shop = await _db.Shops.FindAsync(id);

            if (shop == null)
            {
                return NotFound();
            }
            ApiUtility.ShopUtils(shop, HttpContext.Connection.RemoteIpAddress.ToString());
            _db.Entry(shop).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return shop;
        }

        // POST api/Shops
        /// <summary>
        /// Post a new shop
        /// </summary>
        /// <remarks><b>Post</b> new shop to database </remarks>
        /// <param name="shop"> <b> Name </b> and <b>describe</b> a new shop</param>
        [HttpPost]
        public async Task<ActionResult<Shop>> Post(Shop shop)
        {
            var thisShop = _db.Shops.FirstOrDefault(entry => entry.Name == shop.Name);

            if (thisShop == null)
            {

                _db.Shops.Add(shop);
                shop.SetOriginated(DateTime.Now);
                shop.SetLastAccess(DateTime.Now);
                shop.AddHype(0.25f);
                await _db.SaveChangesAsync();
            }
            else
            {
                return BadRequest();
            }
            return CreatedAtAction("Post", new { id = shop.ShopId }, shop);
        }

        // POST new comment api/Shops/1
        /// <summary>
        /// Post a new remark
        /// </summary>
        /// <remarks><b>Post</b> new remark to a specific shop <b> Not yet implemented </b> </remarks>
        /// <param name="remark"> Access modifiers currently set to public.</param>
        /// <param name="id" example="1"><b>"id" references shop to post to </b> </param>

        [HttpPost("{id}")]
        public async Task<ActionResult<Shop>> Post(int id, Remark remark)
        {
            var thisShop = _db.Shops.FirstOrDefault(entry => entry.ShopId == id);

            if (thisShop != null)
            {
                thisShop.Remarks.Add(remark);
                _db.Entry(thisShop).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            else
            {
                return BadRequest();
            }
            return CreatedAtAction("Post", new { id = thisShop.ShopId }, thisShop);
        }

        // PUT: api/Shops/1
        /// <summary>
        /// Modify details of a specific shop
        /// </summary>
        /// <remarks><b>Put</b> specific shop and modify its details</remarks>
        /// <param name="id" example="1"> ShopId is required to retrieve specific shop</param>
        /// <param name="shop"> Shop <b>name</b> and <b>description</b> may be modified</param>

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
                if (!ShopExists(id))
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
        /// <summary>
        /// Delete a specific shop
        /// </summary>
        /// <remarks><b>Delete</b> shop from database.</remarks>
        /// <param name="id" example="1"> ShopId is required to retrieve specific shop</param>
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