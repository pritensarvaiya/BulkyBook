using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
	public class EmployeeRel
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public EmployeeAddress EmployeeAddress { get; set; }
	}
}
