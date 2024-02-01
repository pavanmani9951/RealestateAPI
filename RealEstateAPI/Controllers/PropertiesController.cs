using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RealEstateAPI.Data;
using System.Security.Claims;
using RealEstateAPI.Models;

namespace RealEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        ApiDbContext _db= new ApiDbContext();



        [HttpGet("PropertyList")]
        [Authorize]
        //to fetch all values of property...and assigned to list
        public IActionResult GetProperties(int categoryId)
        {
            var propertiesResult = _db.Properties.Where(c => c.CategoryId == categoryId);
            if(propertiesResult==null) 
            {
                return NotFound();
            }
            return Ok(propertiesResult);
        }

        [HttpGet("PropertyDetail")]
        [Authorize]
        //to fetch all values of property...
        public IActionResult GetPropertyDetail(int id)
        {
            var propertiesResult = _db.Properties.FirstOrDefault(c => c.Id == id);
            if (propertiesResult == null)
            {
                return NotFound();
            }
            return Ok(propertiesResult);
        }


        [HttpGet("TrendingProperty")]
        [Authorize]
        //to fetch all values of property...
        public IActionResult GetTrendingProperty()
        {
            var propertiesResult = _db.Properties.Where(c => c.IsTrending==true);
            if (propertiesResult == null)
            {
                return NotFound();
            }
            return Ok(propertiesResult);
        }


        [HttpGet("SearchProperty")]
        [Authorize]
        //to fetch all values of property...
        public IActionResult GetSearchProperty(string address)
        {
            var propertiesResult = _db.Properties.Where(c => c.Address.Contains(address));
            if (propertiesResult == null)
            {
                return NotFound();
            }
            return Ok(propertiesResult);
        }


        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Models.Property property)
        {
            if (property == null)
            {
                return NoContent();
            }
            
                var userEmail = User.Claims.FirstOrDefault(c=>c.Type == ClaimTypes.Email)?.Value;
                var user = _db.Users.FirstOrDefault(u => u.Email == userEmail);
                if (user == null) return NotFound();
                property.IsTrending = false;
                property.UserId = user.Id;
                _db.Properties.Add(property);
                _db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] Models.Property property)
        {
            var propertyResult = _db.Properties.FirstOrDefault(u => u.Id == id);
            if (propertyResult == null)
            {
                return NotFound();
            }

            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var user = _db.Users.FirstOrDefault(u => u.Email == userEmail);
            if (user == null) return NotFound();
            if (propertyResult.UserId == user.Id)
            {
                propertyResult.Name = property.Name;
                propertyResult.Detail = property.Detail;
                propertyResult.Price = property.Price;
                propertyResult.Address = property.Address;
                property.IsTrending = false;
                property.UserId = user.Id;
                _db.SaveChanges();
                return Ok("Record updated");
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var propertyResult = _db.Properties.FirstOrDefault(u => u.Id == id);
            if (propertyResult == null)
            {
                return NotFound();
            }

            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var user = _db.Users.FirstOrDefault(u => u.Email == userEmail);
            if (user == null) return NotFound();
            if (propertyResult.UserId == user.Id)
            {
               _db.Properties.Remove(propertyResult);
                _db.SaveChanges();
                return Ok("Record deleted");
            }
            return BadRequest();
        }

    }
}
