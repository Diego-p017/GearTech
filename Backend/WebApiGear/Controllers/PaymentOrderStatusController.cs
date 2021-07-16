using Microsoft.AspNetCore.Mvc;

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
    public class PaymentOrderStatusController : ControllerBase
    {
        private WebApiGearContext _dbContext;
        public PaymentOrderStatusController(WebApiGearContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<PaymentOrderStatusController>
        [HttpGet]
        public IEnumerable<PaymentOrderStatusModel> GettPaymentOrderStatus()
        {
            var list = _dbContext.PaymentOrderStatus.ToList();
            return list;
        }

        // GET api/<PaymentOrderStatusController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentOrderStatusById(int id)
        {
            PaymentOrderStatusModel POSDb = new PaymentOrderStatusModel();
            try
            {
                POSDb = _dbContext.PaymentOrderStatus.Find(id);
                if (POSDb == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(POSDb);
        }

        // POST api/<PaymentOrderStatusController>
        [HttpPost]
        public async Task<IActionResult> PostPaymentOrderStatus([FromBody] PaymentOrderStatusModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _dbContext.PaymentOrderStatus.Add(data);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
            return Ok(data);
        }

        // PUT api/<PaymentOrderStatusController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentOrderStatus(int id, [FromBody] PaymentOrderStatusModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                PaymentOrderStatusModel POSDb = new PaymentOrderStatusModel();
                POSDb = _dbContext.PaymentOrderStatus.Find(id);
                if (POSDb != null)
                {
                    if (data.IdStatus != 0)
                    {
                        POSDb.IdStatus = data.IdStatus;
                    }
                    POSDb.StatusName = data.StatusName;



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

        // DELETE api/<PaymentOrderStatusController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentOrderStatus(int id)
        {
            PaymentOrderStatusModel paymentOrderStatus = _dbContext.PaymentOrderStatus.Find(id);
            if (paymentOrderStatus == null)
            {
                return NotFound();
            }
            _dbContext.Remove(paymentOrderStatus);
            _dbContext.SaveChanges();

            return Ok(paymentOrderStatus);
        }
    }
}
