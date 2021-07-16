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
    public class PurchaseDetailController : ControllerBase
    {
        private WebApiGearContext _dbContext;
        public PurchaseDetailController(WebApiGearContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<PurchaseDetailController>
        [HttpGet]
        public IEnumerable<PurchaseDetailModel> GetPurchaseDetail()
        {
            var list = _dbContext.purchaseDetails.Include(x => x.ProductName).ToList();
            return list;
        }

        // GET api/<PurchaseDetailController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult>  GetPurchaseDetailById(int id)
        {
            PurchaseDetailModel PDDb = new PurchaseDetailModel();
            try
            {
                PDDb = _dbContext.purchaseDetails.Find(id);
                if (PDDb == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            PDDb.ProductName = _dbContext.Products.Find(PDDb.IdProduct);
            return Ok(PDDb);
        }

        // POST api/<PurchaseDetailController>
        [HttpPost]
        public async Task<IActionResult> PostPurchaseDetail([FromBody] PurchaseDetailModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _dbContext.purchaseDetails.Add(data);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
            return Ok(data);
        }

        // PUT api/<PurchaseDetailController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseDetail(int id, [FromBody] PurchaseDetailModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                PurchaseDetailModel PDDb = new PurchaseDetailModel();
                PDDb = _dbContext.purchaseDetails.Find(id);
                if (PDDb != null)
                {
                    if (data.IdPurchase != 0)
                    {
                        PDDb.IdPurchase = data.IdPurchase;
                    }
                    PDDb.PurchasePrice = data.PurchasePrice;
                    PDDb.PurchaseAmount = data.PurchaseAmount;
                    PDDb.IdProduct = data.IdProduct;



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

        // DELETE api/<PurchaseDetailController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseDetail(int id)
        {
            PurchaseDetailModel purchaseDetail = _dbContext.purchaseDetails.Find(id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }
            _dbContext.Remove(purchaseDetail);
            _dbContext.SaveChanges();

            return Ok(purchaseDetail);
        }
    }
}
