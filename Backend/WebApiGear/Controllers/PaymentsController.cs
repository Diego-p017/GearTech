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
    public class PaymentsController : ControllerBase
    {
        private WebApiGearContext _dbContext;
        public PaymentsController(WebApiGearContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<PaymentMethodController>
        [HttpGet]
        public IEnumerable<PaymentsModel> GetPayment()
        {
            var list = _dbContext.Payments.Include(x => x.MethodPayment).Include(x => x.PaymentCart).ToList();
            return list;
        }

        // GET api/<PaymentMethodController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentsById(int id)
        {
            PaymentsModel PDb = new PaymentsModel();
            try
            {
                PDb = _dbContext.Payments.Find();
                if(PDb == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            PDb.MethodPayment = _dbContext.PaymentMethod.Find(PDb.IdMethod);
            PDb.PaymentCart = _dbContext.ShoppingCart.Find(PDb.IdShoppingCart);
            return Ok(PDb);
        }

        // POST api/<PaymentMethodController>
        [HttpPost]
        public async Task<IActionResult> PostPayments(PaymentsModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _dbContext.Payments.Add(data);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
            return Ok(data);
        }

        // PUT api/<PaymentMethodController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayments([FromBody] PaymentsModel data, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                PaymentsModel PDb = new PaymentsModel();
                PDb = _dbContext.Payments.Find(id);
                if (PDb != null)
                {
                    if (data.IdPayment != 0)
                    {
                        PDb.IdPayment = data.IdPayment;
                    }
                    PDb.IdMethod = data.IdMethod;
                    
                   

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

        // DELETE api/<PaymentMethodController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayments(int id)
        {
            PaymentsModel payments = _dbContext.Payments.Find(id);
            if (payments == null)
            {
                return NotFound();
            }
            _dbContext.Remove(payments);
            _dbContext.SaveChanges();

            return Ok(payments);
        }
    }
}
