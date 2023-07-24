using BulkyBook.Data;
using BulkyBook.DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
	public class EmployeeTestRepository : Repository<EmployeeTestRepository>
	{
		private readonly ApplicationDbContext _context;
		public EmployeeTestRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}
	}
}
