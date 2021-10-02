using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrgStructure.Abstractions;
using OrgStructure.Contracts.Common;

namespace OrgStructure.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public sealed class EmployeesController : ControllerBase
	{
		public EmployeesController(
			IEmployeeRepository employeeRepository,
			IMapper mapper)
		{
			EmployeeRepository = Guard.Against.Null(employeeRepository, nameof(employeeRepository));
			Mapper = Guard.Against.Null(mapper, nameof(mapper));
		}

		private IEmployeeRepository EmployeeRepository { get; }

		private IMapper Mapper { get; }

		[HttpGet("{employeeId}")]
		[Produces("application/json")]
		public async Task<EmployeeDto> GetGetEmployeeByIdAsync(
			[FromRoute] string employeeId)
		{
			var employee = await EmployeeRepository.GetEmployeeByIdAsync(employeeId);
			return Mapper.Map<EmployeeDto>(employee);
		}

		[HttpGet]
		[Produces("application/json")]
		public async Task<IEnumerable<EmployeeDto>> GetGetEmployeesAsync()
		{
			var employees = await EmployeeRepository.GetEmployeesAsync();
			return Mapper.Map<IEnumerable<EmployeeDto>>(employees);
		}
	}
}
