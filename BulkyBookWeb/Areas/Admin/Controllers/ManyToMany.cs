using BulkyBook.DataAccess.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ManyToMany : Controller
	{
		protected readonly IUnitOfWork _unitOfWork;
		public ManyToMany(IUnitOfWork unitOfWork)
		{
			_unitOfWork= unitOfWork;	
		}
		public IActionResult Index()
		{
			return Ok("Hello !");
		}
	}
}
