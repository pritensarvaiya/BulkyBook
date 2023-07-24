using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
	public class Department
	{
		[Key]
		public int Id { get; set; }
		[Required,MinLength(4)]
		public string? Code { get; set; }
		[Required]
		public string? Name { get; set; }
	}
}