using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using WebApiGear.Context;
using WebApiGear.Models.Identity;

using WebApiUser.Model.ViewModels;

namespace WebApiGear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private WebApiGearContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthController(WebApiGearContext dbContext,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            _dbContext = dbContext;
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] ViewModelLogin model)
        {
            try
            {
                var us = await _userManager.FindByNameAsync(model.UserName);
                if (us != null)
                {
                   
                        var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                        if (result.Succeeded)
                        {
                            var Location = _dbContext.LocationCity.Find(us.CityId);
                            var roles = await _userManager.GetRolesAsync(us);


                            var appUser = _userManager.Users.SingleOrDefault(u => u.UserName == model.UserName);
                            var token = GenerateJwtToken(model.UserName, appUser);
                      
                            ViewModelUser user = new ViewModelUser()
                            {
                                Id = new Guid(us.Id),
                                FirstName = us.FirstName,
                                LastName = us.LastName,
                                Email = us.Email,
                                LocationId = us.CityId,
                                Location = Location,
                                Phone = us.Phone,
                                DocumentNumber = us.DocumentNumber,
                                Role = roles[0]
                            };

                            return new JsonResult(new ViewModelResponse<ViewModelUser>() { Error = false, Response = "Has iniciado sesión satisfactoriamente", Object = user, Token = token, Status = "Ok" });
                        }
                        else
                        {
                            return new JsonResult(new ViewModelResponse<ViewModelUser>() { Error = true, Response = "Valida tus credenciales.", Status = "ValidaCon" });

                        }
                    
                }
                return new JsonResult(new ViewModelResponse<ViewModelUser>() { Error = true, Response = "Valida tus credenciales. Usuario no encontrado", Status = "ValidaUsu" });
            }
            catch (Exception e)
            {
                string error = String.Format("Ocurrion un error. Intente nuevamente. {0}", e.Message);
                return new JsonResult(new ViewModelResponse<ViewModelUser> { Error = true, Response = error, Status = "Error" });
            }
        }
        [NonAction]
        private object GenerateJwtToken(string email, IdentityUser appUser)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, appUser.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
    
}
