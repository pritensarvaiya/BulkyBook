using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
	public class EmployeeToProject
	{
		[ForeignKey("EmployeeTest")]
		public int EmployeeId { get; set; }
		[ForeignKey("ProjectTest")]
		public int ProjectId { get; set; }
		public EmployeeTest EmployeeTest { get; set; }
		public ProjectTest ProjectTest { get; set; }
	}
}
