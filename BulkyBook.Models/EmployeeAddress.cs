using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
	public class EmployeeAddress
	{
		public int Id { get; set; }
		public int EmployeeRelId { get; set; }
		public EmployeeRel EmployeeRel { get; set; }
		public string? Address { get; set; }
	}
}
