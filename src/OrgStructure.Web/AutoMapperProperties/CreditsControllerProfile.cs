namespace OrgStructure.Web.AutoMapperProperties
{
	using AutoMapper;
	using OrgStructure.Contracts.Common;
	using OrgStructure.Entities;

	public sealed class CreditsControllerProfile : Profile
	{
		public CreditsControllerProfile()
		{
			CreateMap<Credit, CreditDto>();
		}
	}
}
