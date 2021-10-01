using OrgStructure.Contracts.Common;
using OrgStructure.Entities;
using AutoMapper;

namespace OrgStructure.Web.AutoMapperProperties
{
	public sealed class EmployeeControllerProfile : Profile
	{
		public EmployeeControllerProfile()
		{
			CreateMap<Employee, EmployeeDto>();
		}
	}
}
