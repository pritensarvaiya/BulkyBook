﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
	public class ProjectTest
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<EmployeeToProject> EmployeeToProjects { get; set; }
	}
}
