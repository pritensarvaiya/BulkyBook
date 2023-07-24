using BulkyBook.Data;
using BulkyBook.DataAccess.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		private readonly ApplicationDbContext _context;
		public UserRepository(ApplicationDbContext context) : base(context)
		{
			_context=context;
		}
	}
}
