using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Category> Get()
        {
            return _db.Categories;
        }



        [HttpGet("{id:int}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }


        // POST api/<SimpleController>
        [HttpPost]
        public ActionResult<Category> Post([FromBody] Category newCategory)
        {
            //if (newCategory.Id == null)
            //{
            //    return BadRequest();
            //}
            //it has taken the id value by default the primary key 
            //newCategory.Id=_db.Categories.OrderByDescending(c=> c.Id).FirstOrDefault().Id+1;
            _db.Categories.Add(newCategory);
            _db.SaveChanges();
            return Ok(newCategory);
        }

        // PUT api/<SimpleController>/5
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Category>> Put(int id, [FromBody] Category updateCategory)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return BadRequest();
            }
            category.Id = updateCategory.Id;
            category.Name = updateCategory.Name;
            category.ImageUrl = updateCategory.ImageUrl;
            _db.Categories.Update(category);
            _db.SaveChanges();
            return Ok(category);
        }

        // DELETE api/<SimpleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            _db.Categories.Remove(category);
            _db.SaveChanges();
        }
    }
}
