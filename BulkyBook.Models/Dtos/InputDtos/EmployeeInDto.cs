using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models.Dtos.InputDtos
{
	public class EmployeeInDto
	{
		public int Id { get; set; }
		public string? FullName { get; set; }
		public string? Email { get; set; }
		public string? MobileNumber { get; set; }
		public string? City { get; set; }
		public int Gender { get; set; }
		public int EmployeeDepartment { get; set; }
		public DateTime HireDate { get; set; }
		public Boolean IsPermanent { get; set; }
	}
}
