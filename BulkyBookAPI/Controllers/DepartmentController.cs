using BulkyBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BulkyBook.DataAccess.IRepository;

namespace BulkyBookAPI.Controllers
{
	[Route("api/Department")]
	[ApiController]
	public class DepartmentController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public DepartmentController(IUnitOfWork unitOfWork)
		{
			_unitOfWork= unitOfWork;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<IEnumerable<Department>> GetAllDepartment()
		{
			IEnumerable<Department> objDepartmentList = _unitOfWork.Department.GetAll();
			if (objDepartmentList == null)
				return NotFound();
			return Ok(objDepartmentList);
		}
	}
}
