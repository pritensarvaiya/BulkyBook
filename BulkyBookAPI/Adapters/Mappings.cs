using AutoMapper;
using BulkyBook.Models;
using BulkyBook.Models.Dtos;

namespace BulkyBookAPI.Adapters
{
	public class Mappings :Profile 
	{
		public Mappings()
		{
			CreateMap<EmployeeDto, Employee>()
				.ReverseMap()
				.ForMember(employeeDto => employeeDto.ParmanentOrNot, x => x.MapFrom(employee => employee.IsPermanent ? "Yes" : "No"))
				.ForMember(employeeDto => employeeDto.employeeDepartment, x => x.MapFrom(employee => employee.Department.Name))
				.ForMember(empoyeeDto=> empoyeeDto.GenderName,x=>x.MapFrom(employee=>employee.Gender));

			CreateMap<UserDto, User>().ReverseMap();

			//CreateMap<EmployeeInDto, Employee>()
			//	.ForMember(employee => employee.DepartmentId, x => x.MapFrom(employeeDto => employeeDto.EmployeeDepartment));
			//CreateMap<Employee, EmployeeOutDto>()
			//	.ForMember(employeeDto => employeeDto.IsPermanent, x => x.MapFrom(employee => employee.IsPermanent?"Yes":"No"))
			//	.ForMember(employeeDto=> employeeDto.employeeDepartment, x=>x.MapFrom(employee=> employee.Department.Name));
		}
	}
}
