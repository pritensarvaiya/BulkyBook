using BulkyBook.Data;
using BulkyBook.DataAccess.IRepository;
using BulkyBook.Models;
using DemoWebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
	public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
	{
		private readonly ApplicationDbContext _context;
		public EmployeeRepository(ApplicationDbContext context) : base(context)
		{
			_context= context;
		}

		public void Update(Employee employee)
		{
			var employeeFromDB = _context.Employees.FirstOrDefault(u => u.Id == employee.Id);
			if (employeeFromDB != null)
			{
				employeeFromDB.FullName = employee.FullName;
				employeeFromDB.Email = employee.Email;
				employeeFromDB.MobileNumber = employee.MobileNumber;
				employeeFromDB.Gender = employee.Gender;
				employeeFromDB.City	= employee.City;
				employeeFromDB.HireDate = employee.HireDate;
				employeeFromDB.IsPermanent= employee.IsPermanent;
				employeeFromDB.DepartmentId= employee.DepartmentId;
			}
		}
	}
}
