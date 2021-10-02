using OrgStructure.Contracts.Common;
using OrgStructure.Entities;
using AutoMapper;

namespace OrgStructure.Web.AutoMapperProperties
{
	public sealed class EmployeesControllerProfile : Profile
	{
		public EmployeesControllerProfile()
		{
			CreateMap<Employee, EmployeeDto>();
		}
	}
}
