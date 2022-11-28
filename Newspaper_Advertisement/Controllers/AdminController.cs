//using Newspaper_Advertisement.DataAccessLayer;
using Newspaper_Advertisement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Newspaper_Advertisement.Controllers
{

    [Route("api/auth")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] AdminModel admin)
        {
            if (admin == null)
                return BadRequest("Invalid client request");

            if (admin.adminId == "admin_123" && admin.password == "admin@123")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:41574",
                    audience: "http://localhost:41574",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signingCredentials
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }
            return Unauthorized();
        }
    }
}

