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
    public class PaymentMethodController : ControllerBase
    {
        private WebApiGearContext _dbContext;
        public PaymentMethodController(WebApiGearContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<PaymentsController>
        [HttpGet]
        public IEnumerable<PaymentMethodModel> GetPaymentMethod()
        {
            var list = _dbContext.PaymentMethod.ToList();
            return list;
        }

        // GET api/<PaymentsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentMethodById(int id)
        {
            PaymentMethodModel PMDb = new PaymentMethodModel();
            try
            {
                PMDb = _dbContext.PaymentMethod.Find(id);
                if (PMDb == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(PMDb);
        }

        // POST api/<PaymentsController>
        [HttpPost]
        public async Task<IActionResult> PostPaymentMethod([FromBody] PaymentMethodModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _dbContext.PaymentMethod.Add(data);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
            return Ok(data);
        }

        // PUT api/<PaymentsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentMethod(int id, [FromBody] PaymentMethodModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                PaymentMethodModel PMDb = new PaymentMethodModel();
                PMDb = _dbContext.PaymentMethod.Find(id);
                if (PMDb != null)
                {
                    if (data.IdMethod != 0)
                    {
                        PMDb.IdMethod = data.IdMethod;
                    }
                    PMDb.PaymentDate = data.PaymentDate;
                    PMDb.MethodDescription = data.MethodDescription;

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

        // DELETE api/<PaymentsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentMethod(int id)
        {
            PaymentMethodModel paymentMethod = _dbContext.PaymentMethod.Find(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }
            _dbContext.Remove(paymentMethod);
            _dbContext.SaveChanges();

            return Ok(paymentMethod);
        }
    }
}
