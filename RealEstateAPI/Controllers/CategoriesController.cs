using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateAPI.Data;
using RealEstateAPI.Models;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace RealEstateAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		//public List<Category> categories = new List<Category>
		//{
		//    new Category { Id = 1,Name="Villa",ImageUrl=""},
		//    new Category { Id = 2,Name="Beach villa",ImageUrl=""},
		//    new Category { Id = 3,Name="Ocean villa",ImageUrl=""}

		//};
		[HttpGet]
		public ActionResult<IEnumerable<Category>> GetCategories()
		{
			return Ok(CategoryStore.categories);
		}

		[HttpGet("{id:int}")]
		public ActionResult<Category> GetCategory(int id)
		{
			var category = CategoryStore.categories.FirstOrDefault(c => c.Id == id);
			if (category == null)
			{
				return NotFound();
			}
			return Ok(category);
		}

		[HttpPost]
		public ActionResult<IEnumerable<Category>> PostCategories([FromBody] Category newCategory)
		{
			if (newCategory == null)
			{
				return BadRequest();
			}
			newCategory.Id = CategoryStore.categories.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
			CategoryStore.categories.Add(newCategory);
			return Ok(newCategory);

		}


		[HttpPut("{id}")]
		public ActionResult<IEnumerable<Category>> UpdateCategories(int id, [FromBody] Category updateCategory)
		{
			var category = CategoryStore.categories.FirstOrDefault(c => c.Id == id);
			if (category == null)
			{
				return BadRequest();
			}
			category.Id = updateCategory.Id;
			category.Name = updateCategory.Name;
			category.ImageUrl = updateCategory.ImageUrl;
			return Ok(category);
		}

		[HttpDelete]
		public ActionResult<IEnumerable<Category>> DeleteCategories(int id)
		{
			var category = CategoryStore.categories.FirstOrDefault(c => c.Id == id);
			if (category == null)
			{
				return BadRequest();
			}
			CategoryStore.categories.Remove(category);
			return Ok(category);
		}
	
	}


}