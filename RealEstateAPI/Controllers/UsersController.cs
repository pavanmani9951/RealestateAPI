using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateAPI.Data;
using RealEstateAPI.Models;

namespace RealEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
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
    }
}
