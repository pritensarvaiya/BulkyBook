using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models.Dtos.OutputDtos
{
	public class EmployeeOutDto
	{
		public int Id { get; set; }
		public string? FullName { get; set; }
		public string? Email { get; set; }
		public string? MobileNumber { get; set; }
		public string? City { get; set; }
		public string? Gender { get; set; }
		public string? employeeDepartment { get; set; }
		public DateTime HireDate { get; set; }
		public string? IsPermanent { get; set; }
	}
}
