using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentManagementWebApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManagementWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        // GET: api/<SecurityController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SecurityController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        private string GenerateJSONWebToken(string username)
        {
            // header info
            var algo = SecurityAlgorithms.HmacSha256;
            // select username...email,male
            // payload info
            var claims = new[] {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Email, ""),
                new Claim("IsAdmin", "True"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            // signature
            var key = "your-32-byte-long-secret-key@1234";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, algo);
            var token = new JwtSecurityToken("Questpond",
               "BrowserClients",
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // POST api/<SecurityController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if ((user.UserName == "Alisha") && (user.Password == "Alisha123"))
            {
                Token t = new Token();
                t.value = GenerateJSONWebToken(user.UserName);
                return Ok(t);
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "User not exist");
            }

        }

        // PUT api/<SecurityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SecurityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
