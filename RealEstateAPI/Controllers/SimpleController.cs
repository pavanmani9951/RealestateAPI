/*using Microsoft.AspNetCore.Mvc;
using RealEstateAPI.Data;
using RealEstateAPI.Models;


namespace RealEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleController : ControllerBase
    {
        // we have to use dependency injection or dbcontext instance hereee.....

        ApiDbContext _db = new ApiDbContext();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Categories);
        }



        [HttpGet("{id:int}")]
        public IActionResult GetCategory(int id)
        {
            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpGet("[action]")]
        public IActionResult SortCategories()
        {
            return Ok(_db.Categories.OrderByDescending(u => u.Name));
        }


        // POST api/<SimpleController>
        [HttpPost]
        public IActionResult Post([FromBody] Category newCategory)
        {
            //if (newCategory.Id == null)
            //{
            //    return BadRequest();
            //}
            //it has taken the id value by default the primary key so no need to use the below method.
            //newCategory.Id=_db.Categories.OrderByDescending(c=> c.Id).FirstOrDefault().Id+1;
            _db.Categories.Add(newCategory);
            _db.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<SimpleController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category updateCategory)
        {
            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound("no record founded");
            }
            
            category.Name = updateCategory.Name;
            category.ImageUrl = updateCategory.ImageUrl;
            //_db.Categories.Update(category);
            _db.SaveChanges();
            return Ok(category);
        }

        // DELETE api/<SimpleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound("no record found to delete");
            }
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return Ok("Deleted successfully");
        }
    }
}
*/