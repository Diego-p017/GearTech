using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiGear.Context;
using WebApiGear.Models;

namespace WebApiGear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrademarkController : ControllerBase
    {
        private WebApiGearContext _dbContext;
        public TrademarkController(WebApiGearContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<TrademarkController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrademarkModel>>> GetTradeMark()
        {
            return await _dbContext.Trademark.ToListAsync();
            
        }

        // GET api/<TrademarkController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTradeMarkById(int id)
        {
            TrademarkModel TMDb = new TrademarkModel();
            try
            {
                TMDb = _dbContext.Trademark.Find(id);
                if (TMDb == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;   
            }
            return Ok(TMDb);
        }

        // POST api/<TrademarkController>
        [HttpPost]
        public async Task<IActionResult> PostTradeMark(TrademarkModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _dbContext.Trademark.Add(data);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
            return Ok(data);
        }

        // PUT api/<TrademarkController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTradeMarkBy(TrademarkModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                TrademarkModel TMDb = new TrademarkModel();
                TMDb = _dbContext.Trademark.Find(data.IdTrademark);
                  if(TMDb != null){
                    TMDb.TrademarkName = data.TrademarkName;
                  }
                  int i = this._dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
            return Ok(data);
        }

        // DELETE api/<TrademarkController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTradeMark(int id)
        {
            TrademarkModel trademark = _dbContext.Trademark.Find(id);
            if(trademark == null)
            {
                return NotFound();
            }
            _dbContext.Remove(trademark);
            _dbContext.SaveChanges();

            return Ok(trademark);
        }
    }
}
