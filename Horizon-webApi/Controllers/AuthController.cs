using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HorizonWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HorizonWebApi.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly HorizonWebApiContext _context;

        public AuthController(HorizonWebApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]Login employee)
        {
            if (employee == null)
            {
                return BadRequest("Invalid client request");
            }

            var employees = await _context.Employee.SingleOrDefaultAsync(m => m.username == employee.username);

            if (employees == null)
            {
                return NotFound();
            }

            if (employee.username == employees.username && employee.password == employees.password)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:31489",
                    audience: "http://localhost:31489",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }

    }
        
}