using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RealEstateAPI.Data;
using RealEstateAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // we have to inject Iconfig here to get access to appsetings.json
        private IConfiguration _config;
        public UsersController(IConfiguration config) 
        {
            _config = config;
        }

        // we have to use dependency injection or dbcontext instance hereee..... to get acccess to db

        ApiDbContext _db = new ApiDbContext();
        
        [HttpPost("[action]")]
        public IActionResult Register([FromBody] User newUser)
        {
            var userExists = _db.Users.FirstOrDefault(u=>u.Email == newUser.Email);
            if (userExists != null)
            {
                return BadRequest("User already exists ");
            }
            _db.Users.Add(newUser);
            _db.SaveChanges();
            return Ok(newUser);
        }

        [HttpPost("[action]")]

        public IActionResult Login([FromBody] User user)
        {
            var currentUser = _db.Users.FirstOrDefault(u=>u.Email == user.Email && u.Password==user.Password);
            if (currentUser == null) 
            {
                return NotFound("Enter the credentials to login");
            }

            // if user found generate jwt token
            // SymmetricSecurityKey is used to encryot and decrypt the data..
            //security key is the public key
            var securityKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            //signingcredentials class is used for hashing
            
            // in header we specify the algorithm and type of it
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //payload ... what we are storing example : email 
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email)
            };

            //signature

            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token); // this line return token in string format 
            return Ok(jwt);
        }
    }
}
