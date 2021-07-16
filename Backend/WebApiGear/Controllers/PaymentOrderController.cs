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
    public class PaymentOrderController : ControllerBase
    {
        private WebApiGearContext _dbContext;
        public PaymentOrderController(WebApiGearContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<PaymentOrderController>
        [HttpGet]
        public IEnumerable<PaymentOrderModel> Get()
        {
            var list = _dbContext.PaymentOrder.Include(x => x.PaymentOrder).Include(x => x.StatusOrder).ToList();
            return list;
        }

        // GET api/<PaymentOrderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentOrderById(int id)
        {
            PaymentOrderModel PODb = new PaymentOrderModel();
            try
            {
                PODb = _dbContext.PaymentOrder.Find(id);
                if (PODb == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            PODb.PaymentOrder = _dbContext.Payments.Find(PODb.IdPayment);
            PODb.StatusOrder = _dbContext.PaymentOrderStatus.Find(PODb.IdStatus);
            return Ok(PODb);
        }

        // POST api/<PaymentOrderController>
        [HttpPost]
        public async Task<IActionResult> PostPAymentOrder([FromBody] PaymentOrderModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _dbContext.PaymentOrder.Add(data);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
            return Ok(data);
        }

        // PUT api/<PaymentOrderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentOrder(int id, [FromBody] PaymentOrderModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                PaymentOrderModel PODb = new PaymentOrderModel();
                PODb = _dbContext.PaymentOrder.Find(id);
                if (PODb != null)
                {
                    if (data.IdPayment != 0)
                    {
                        PODb.IdPayment = data.IdPayment;
                    }
                    PODb.IdStatus = data.IdStatus;



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

        // DELETE api/<PaymentOrderController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentOrder(int id)
        {
            PaymentOrderModel paymentOrder = _dbContext.PaymentOrder.Find(id);
            if (paymentOrder == null)
            {
                return NotFound();
            }
            _dbContext.Remove(paymentOrder);
            _dbContext.SaveChanges();

            return Ok(paymentOrder);
        }
    }
}
