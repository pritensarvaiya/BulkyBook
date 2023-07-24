using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string? FullName { get; set; }
		[Required,EmailAddress]
		public string? Email { get; set; }
		[Required,MinLength(10),MaxLength(10)]
		public string? MobileNumber { get; set; }
		public string? City { get; set; }
		public Gender Gender { get; set; }
		[DisplayName("Department")]
		public int DepartmentId { get; set; }
		public Department Department { get; set; }
		public DateTime HireDate { get; set; }
		public Boolean IsPermanent { get; set; }

	}

	public enum Gender
	{
		Male,
		Female,
		Other
	}
}
