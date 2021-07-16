using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiGear.Context;
using WebApiGear.Models.Identity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiGear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private WebApiGearContext _dbContext;
        public LocationController(WebApiGearContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<LocationController>
        [HttpGet]
        public IEnumerable<LocationModel> GetLocation()
        {
            var list = _dbContext.LocationCity.ToList();
            return list;
        }

        // GET api/<LocationController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            LocationModel LMDb = new LocationModel();
            try
            {
                LMDb = _dbContext.LocationCity.Find(id);
                if (LMDb == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(LMDb);
        }

        // POST api/<LocationController>
        [HttpPost]
        public async Task<IActionResult> PostLocation(LocationModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _dbContext.LocationCity.Add(data);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
            return Ok(data);
        }

        // PUT api/<LocationController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(LocationModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                LocationModel LMDb = new LocationModel();
                LMDb = _dbContext.LocationCity.Find(data.CityId);
                if (LMDb != null)
                {
                    LMDb.CityName = data.CityName;
                }
                int i = this._dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
            return Ok(data);
        }

        // DELETE api/<LocationController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            LocationModel location = _dbContext.LocationCity.Find(id);
            if (location == null)
            {
                return NotFound();
            }
            _dbContext.Remove(location);
            _dbContext.SaveChanges();

            return Ok(location);
        }
    }
}
