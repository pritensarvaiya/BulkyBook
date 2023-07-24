using AutoMapper;
using BulkyBook.DataAccess.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookAPI.Controllers
{
	[Route("api/Employee")]
	[ApiController]
	[Authorize]
	public class EmployeeController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public EmployeeController(IUnitOfWork unitOfWork,IMapper mapper)
		{
			_unitOfWork= unitOfWork;
			_mapper= mapper;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public ActionResult<IEnumerable<EmployeeDto>> GetAllEmployees()
		{
			IEnumerable<Employee> objEmployeeList = _unitOfWork.Employee.GetAll(includeProperties: "Department").OrderBy(x=>x.Id);
			if (objEmployeeList == null)
				return NotFound();

			IEnumerable<EmployeeDto> employeeList = _mapper.Map<List<EmployeeDto>>(objEmployeeList);
			return Ok(employeeList);
		}

		[HttpGet("{id:int}", Name = "GetEmployee")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public ActionResult<EmployeeDto> GetEmployee(int id)
		{
			if (id == 0)
				return NotFound();
			Employee employee = _unitOfWork.Employee.GetFirstOrDefault(u => u.Id == id, includeProperties: "Department");
			EmployeeDto employeeList = _mapper.Map<EmployeeDto>(employee);
			if (employee == null)
				return NotFound();
			return Ok(employeeList);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public ActionResult<Employee> CreateEmployee([FromBody] EmployeeDto employeeDTO)
		{
			if (employeeDTO == null)
				return BadRequest();
			if (employeeDTO.Id != 0)
				return StatusCode(StatusCodes.Status500InternalServerError);
			Employee employee = _mapper.Map<Employee>(employeeDTO);
			_unitOfWork.Employee.Add(employee);
			_unitOfWork.Save();
			return CreatedAtRoute("GetCategory", new { id = employee.Id }, employee);
		}

		[HttpDelete("{id:int}", Name = "DeleteEmployee")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public ActionResult<Employee> DeleteEmployee(int id)
		{
			if (id == 0)
				return NotFound();
			var employee = _unitOfWork.Employee.GetFirstOrDefault(u => u.Id == id);
			if (employee == null)
				return NotFound();
			_unitOfWork.Employee.Remove(employee);
			_unitOfWork.Save();
			return NoContent();
		}

		[HttpPut("{id:int}", Name = "UpdateEmployee")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public ActionResult UpdateEmployee(int id, [FromBody] EmployeeDto employeeDTO)
		{
			if (employeeDTO == null || id != employeeDTO.Id) return BadRequest();
			var employeeDb = _unitOfWork.Employee.GetFirstOrDefault(u => u.Id == id);
			if (employeeDb == null) return NotFound();
			Employee employee = _mapper.Map<Employee>(employeeDTO);
			_unitOfWork.Employee.Update(employee);
			_unitOfWork.Save();
			return NoContent();
		}
	}
}
