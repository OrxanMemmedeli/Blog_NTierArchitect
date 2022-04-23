using BlogApiDemo.Data;
using BlogApiDemo.GenerateToken;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginData)
        {

            if (ModelState.IsValid)
            {
                var user = SystemUsers.FillModel().FirstOrDefault(x => x.UserName.ToLower() == loginData.Username.ToLower() && x.Password == loginData.Password);

                return user != null ? Ok(new { token = GenerateJwt.CreateToken(_configuration["jwtSecret"], user) }) : Unauthorized();
            }

            return BadRequest(ModelState);
        }
    }
}
