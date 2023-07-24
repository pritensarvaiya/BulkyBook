using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models.Dtos
{
	public class EmployeeDto
	{
		public int Id { get; set; }
		public string? FullName { get; set; }
		public string? Email { get; set; }
		public string? MobileNumber { get; set; }
		public string? City { get; set; }
		public Gender Gender { get; set; }
		public int DepartmentId { get; set; }
		//public Department? Department { get; set; }
		public DateTime HireDate { get; set; }
		public Boolean IsPermanent { get; set; }
		public string? GenderName { get; set; }
		public string? employeeDepartment { get; set; }
		public string? ParmanentOrNot { get; set; }
	}
}
