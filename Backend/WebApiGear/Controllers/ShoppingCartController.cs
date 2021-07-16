using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiGear.Context;
using WebApiGear.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiGear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private WebApiGearContext _dbContext;
        public ShoppingCartController(WebApiGearContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<ShoppingCartController>
        [HttpGet]
        public IEnumerable<ShoppingCartModel> GetShoppingCart()
        {
            var list = _dbContext.ShoppingCart.Include(x => x.PurchasePrice).Include(x => x.UserCart).ToList();
            return list;
        }

        // GET api/<ShoppingCartController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShoppingCartById(int id)
        {
            ShoppingCartModel SCDb = new ShoppingCartModel();
            try
            {
                SCDb = _dbContext.ShoppingCart.Find(id);
                if (SCDb == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            SCDb.PurchasePrice = _dbContext.purchaseDetails.Find(SCDb.IdPurchase);
            SCDb.UserCart = _dbContext.AspNetUsers.Find(SCDb.id);
            return Ok(SCDb);
        }

        // POST api/<ShoppingCartController>
        [HttpPost]
        public async Task<IActionResult> PostShoppingCart([FromBody] ShoppingCartModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _dbContext.ShoppingCart.Add(data);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
            return Ok(data);
        }

        // PUT api/<ShoppingCartController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingCart(int id, [FromBody] ShoppingCartModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                ShoppingCartModel SCDb = new ShoppingCartModel();
                SCDb = _dbContext.ShoppingCart.Find(id);
                if (SCDb != null)
                {
                    if (data.IdShoppingCart != 0)
                    {
                        SCDb.IdShoppingCart = data.IdShoppingCart;
                    }
                    SCDb.IdPurchase = data.IdPurchase;
                    SCDb.id = data.id;


                    //   _dbContext.Category.Update(CMDb);
                }
                int i = this._dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
            return Ok(data);
        }

        // DELETE api/<ShoppingCartController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingCart(int id)
        {
            ShoppingCartModel shoppingCart = _dbContext.ShoppingCart.Find(id);
            if (shoppingCart == null)
            {
                return NotFound();
            }
            _dbContext.Remove(shoppingCart);
            _dbContext.SaveChanges();

            return Ok(shoppingCart);
        }
    }
}
