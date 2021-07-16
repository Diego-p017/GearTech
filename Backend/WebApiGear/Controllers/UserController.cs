using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiGear.Context;
using WebApiGear.Models.Identity;

using WebApiUser.Model.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiGear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private WebApiGearContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public UserController(WebApiGearContext dbContext,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _configuration = configuration;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<ApplicationUser> GetUser()
        {
            var list = _dbContext.AspNetUsers.Include(x => x.Location).ToList();
            return list;

        }

        //// GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetUserById(int id)
        //{
        //    ViewModelUser CMDb = new ViewModelUser();
        //    try
        //    {
        //        CMDb = _dbContext.AspNetUsers.Find(id);
        //        if (CMDb == null)
        //        {
        //            return NotFound();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    CMDb.Location = _dbContext.LocationCity.Find(CMDb.LocationId);
        //    return Ok(CMDb);
        //}

        // POST api/<UserController>
        //[HttpPost]
        //public async Task<IActionResult> PostUser([FromBody] ApplicationUser data)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        _dbContext.AspNetUsers.Add(data);
        //        _dbContext.SaveChanges();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return Ok(data);
        //
        //[AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> UserRegister([FromBody] ViewModelUser model)
        {
            try
            {
                if (!model.Password.Equals(model.ConfirmedPassword))
                {
                    return new JsonResult(new ViewModelResponse<object>() { Error = true, Response = "Las contraseñas no coinciden" });
                }

                if (!model.Email.Equals(model.ConfirmedEmail))
                {
                    return new JsonResult(new ViewModelResponse<object>() { Error = true, Response = "Los correos electrónicos no coinciden no coincide" });
                }

                var userDB = await _userManager.FindByEmailAsync(model.Email);

                if (userDB != null)
                {
                    return new JsonResult(new ViewModelResponse<object>() { Error = true, Response = "El correo electrónico ya está registrado, inicia sesión" });
                }

                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    DocumentNumber = model.DocumentNumber,
                    Phone = model.Phone,
                    PhoneNumber = model.Phone,
                    Address = model.Address,
                    CityId = model.LocationId

                    

                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // create role 
                    await _userManager.AddToRoleAsync(user, model.Role);

                    return new JsonResult(new ViewModelResponse<object>() { Error = false, Response = "Usuario registrado satisfactoriamente." });
                }
                return new JsonResult(new ViewModelResponse<object>() { Error = true, Response = "La contraseña debe tener un dígito, una letra minúscula, un caracter no alfanumérico, almenos una letra mayúscula y su longitud debe ser mayor o igual a 8 caracteres." });
            }
            catch (Exception e)
            {
                return new JsonResult(new ViewModelResponse<object>()
                {
                    Error = true,
                    Response = String.Format("Ocurrio un error , intenta nuevamente. {0}", e.Message)
                });
            }
        }

        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser(int id, [FromBody] ViewModelUser data)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        CategoryModel CMDb = new CategoryModel();
        //        CMDb = _dbContext.Category.Find(id);
        //        if (CMDb != null)
        //        {
        //            if (data.IdTrademark != 0)
        //            {
        //                CMDb.IdTrademark = data.IdTrademark;
        //            }
        //            CMDb.CategoryName = data.CategoryName;



        //            //   _dbContext.Category.Update(CMDb);
        //        }
        //        int i = this._dbContext.SaveChanges();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return Ok(data);
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUser(int id)
        //{
        //    ViewModelUser user = _dbContext.AspNetUsers.Find(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    _dbContext.Remove(user);
        //    _dbContext.SaveChanges();

        //    return Ok(user);
        //}
    }
}
