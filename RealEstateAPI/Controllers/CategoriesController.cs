using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateAPI.Data;

namespace RealEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ApiDbContext _db = new ApiDbContext();
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(_db.Categories);
        }
    }
}
