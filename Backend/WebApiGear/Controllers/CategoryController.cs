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
    public class CategoryController : ControllerBase
    {
        private WebApiGearContext _dbContext;
        public CategoryController(WebApiGearContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<CategoryModel> GetCategory()
        {
            var list = _dbContext.Category.Include(x => x.TrademarkName).ToList();
            return list;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            CategoryModel CMDb = new CategoryModel();
            try
            {
                CMDb = _dbContext.Category.Find(id);
                if (CMDb == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            CMDb.TrademarkName = _dbContext.Trademark.Find(CMDb.IdTrademark);
            return Ok(CMDb);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> PostCategory(CategoryModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _dbContext.Category.Add(data);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
            return Ok(data);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory([FromBody] CategoryModel data, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CategoryModel CMDb = new CategoryModel();
                CMDb = _dbContext.Category.Find(id);
                if (CMDb != null)
                {
                    if (data.IdTrademark != 0)
                    {
                        CMDb.IdTrademark = data.IdTrademark;
                    }                    
                     CMDb.CategoryName = data.CategoryName;
                    
                   

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

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            CategoryModel category = _dbContext.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _dbContext.Remove(category);
            _dbContext.SaveChanges();

            return Ok(category);
        }
    }
}
