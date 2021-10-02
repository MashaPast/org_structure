using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrgStructure.Abstractions;
using OrgStructure.Contracts.Common;

namespace OrgStructure.Web.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public sealed class CreditsController : ControllerBase
	{
		public CreditsController(
			ICreditsRepository employeeRepository,
			IMapper mapper)
		{
			CreditsRepository = Guard.Against.Null(employeeRepository, nameof(employeeRepository));
			Mapper = Guard.Against.Null(mapper, nameof(mapper));
		}

		private ICreditsRepository CreditsRepository { get; }

		private IMapper Mapper { get; }

		[HttpGet]
		[Produces("application/json")]
		public async Task<IEnumerable<CreditDto>> GetGetEmployeesAsync()
		{
			var credits = await CreditsRepository.GetCreditsAsync();
			return Mapper.Map<IEnumerable<CreditDto>>(credits);
		}
	}
}
