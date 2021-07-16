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
    public class ProductsController : ControllerBase
    {
        private WebApiGearContext _dbContext;
        public ProductsController(WebApiGearContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<ProductsModel> GetProducts()
        {
            var list = _dbContext.Products.Include(x => x.Category).ToList();
            return list;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsById(int id)
        {
            ProductsModel PDb = new ProductsModel();
            try
            {
                PDb = _dbContext.Products.Find(id);
                if (PDb == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            PDb.Category = _dbContext.Category.Find(PDb.IdCategory);
            return Ok(PDb);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<ProductsModel>> PostPaymentDetailModel(ProductsModel ProductsModel)
        {
            _dbContext.Products.Add(ProductsModel);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetProductsById", new { id = ProductsModel.IdProduct }, ProductsModel);
        }
        //[HttpPost]
        //public async Task<IActionResult> PostProducts([FromBody]  ProductsModel data)
        //{
        //    //ProductsModel product = new ProductsModel()
        //    //{
        //    //    ProductName = data.ProductName,
        //    //    ProductPrice = data.ProductPrice,
        //    //    ProductStock = data.ProductStock,
        //    //    ImageProduct = data.ImageProduct,
        //    //    IdCategory = data.IdCategory
        //    //};
        //    //return Ok(data);


        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        ProductsModel PDb = new ProductsModel();
        //        if (PDb != null)
        //        {
        //            if (data.IdProduct != 0)
        //            {
        //                PDb.IdProduct = data.IdProduct;
        //            }
        //            PDb.ProductName = data.ProductName;
        //            PDb.ProductPrice = data.ProductPrice;
        //            PDb.ProductStock = data.ProductStock;
        //            PDb.ImageProduct = data.ImageProduct;
        //            PDb.IdCategory = data.IdCategory;

        //           _dbContext.Products.Add(PDb);
        //        }
        //        int i = this._dbContext.SaveChanges();
        //    }
        //    catch(Exception e)
        //    {
        //        throw new Exception("Error Inesperado", e);                
        //    }
        //    return Ok(data);
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return BadRequest(ModelState);
        //    //}
        //    //try
        //    //{
        //    //    _dbContext.Products.Add(data);
        //    //    _dbContext.SaveChanges();
        //    //}
        //    //catch
        //    //{
        //    //    throw;
        //    //}
        //    //return Ok(data);
        //}


        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id,[FromBody] ProductsModel data)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                ProductsModel PDb = new ProductsModel();
                PDb = _dbContext.Products.Find(id);
                if (PDb != null)
                {
                    if (data.IdProduct != 0)
                    {
                        PDb.IdProduct = data.IdProduct;
                    }
                    PDb.ProductName = data.ProductName;
                    PDb.ProductPrice = data.ProductPrice;
                    PDb.ProductStock = data.ProductStock;
                    PDb.Specifications = data.Specifications;
                    PDb.Description = data.Description;
                    PDb.ImageProduct = data.ImageProduct;
                    PDb.IdCategory = data.IdCategory;

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

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducts(int id)
        {
            ProductsModel products = _dbContext.Products.Find(id);
            if (products == null)
            {
                return NotFound();
            }
            _dbContext.Remove(products);
            _dbContext.SaveChanges();

            return Ok(products);
        }
    }
}
