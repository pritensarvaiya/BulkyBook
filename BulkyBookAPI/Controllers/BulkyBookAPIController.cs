using BulkyBook.DataAccess.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookAPI.Controllers
{
	[Route("api/BulkyBook")]
	[ApiController]
	public class BulkyBookAPIController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public BulkyBookAPIController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<IEnumerable<Category>> GetAllCategories()
		{
			// Using Dapper
			var data = _unitOfWork.Category.getCategoriesDemo();

			IEnumerable<Category> objCategoryList = _unitOfWork.Category.GetAll();
			if (objCategoryList == null)
				return NotFound();
			return Ok(objCategoryList);
		}

		[HttpGet("{id:int}", Name = "GetCategory")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<Category> GetCategory(int id)
		{
			if (id == 0)
				return NotFound();
			var category = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
			if (category == null)
				return NotFound();
			return Ok(category);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public ActionResult<Category> CreateCategory([FromBody] Category category)
		{
			if (category == null)
				return BadRequest();
			if (category.Id != 0)
				return StatusCode(StatusCodes.Status500InternalServerError);
			_unitOfWork.Category.Add(category);
			_unitOfWork.Save();
			return CreatedAtRoute("GetCategory", new { id = category.Id }, category);
		}

		[HttpDelete("{id:int}",Name = "DeleteCategory")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public ActionResult<Category> DeleteCategory(int id)
		{
			if (id == 0)
				return NotFound();
			var category = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
			if (category == null)
				return NotFound();
			_unitOfWork.Category.Remove(category);
			_unitOfWork.Save();
			return NoContent();
		}

		[HttpPut("{id:int}",Name = "UpdateCategory")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public ActionResult UpdateCategory(int id, [FromBody]Category category)
		{
			if(category==null||id!=category.Id) return BadRequest();
			var categoryDb = _unitOfWork.Category.GetFirstOrDefault(u=>u.Id==id);
			if(categoryDb == null) return NotFound();
			_unitOfWork.Category.Update(category);
			_unitOfWork.Save();
			return NoContent();
		}

		[HttpPatch("{id:int}",Name ="UpdatePartialCategory")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult UpdatePartialCategory(int id,[FromBody] JsonPatchDocument<Category> patchDTO)
		{
			if (patchDTO == null || id == 0) return BadRequest();
			var categoryDb = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
			if (categoryDb == null) return NotFound();
			patchDTO.ApplyTo(categoryDb,ModelState);
			_unitOfWork.Save();
			if (!ModelState.IsValid) return BadRequest(ModelState);
			return NoContent();
		}
	}
}