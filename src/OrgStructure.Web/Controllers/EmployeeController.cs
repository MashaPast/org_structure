using System.Collections.Generic;
using System.Threading.Tasks;
using OrgStructure.Abstractions;
using OrgStructure.Contracts.Common;
using OrgStructure.Contracts.GetEmployeeById;
using OrgStructure.Contracts.GetEmployees;
using Ardalis.GuardClauses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace OrgStructure.Controllers
{

	[ApiController]
	[Route("api/[controller]")]
	public sealed class EmployeeController : ControllerBase
	{
		public EmployeeController(
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
		public async Task<GetEmployeeByIdQueryResult> GetGetEmployeeByIdAsync(
			[FromRoute] string employeeId)
		{
			var employee = await EmployeeRepository.GetEmployeeByIdAsync(employeeId);
			var employeeDto = Mapper.Map<EmployeeDto>(employee);

			return new GetEmployeeByIdQueryResult(employeeDto);
		}

		[HttpGet]
		[Produces("application/json")]
		public async Task<GetEmployeesQueryResult> GetGetEmployeesAsync()
		{
			var employees = await EmployeeRepository.GetEmployeesAsync();
			var employeesDto = Mapper.Map<IEnumerable<EmployeeDto>>(employees);

			return new GetEmployeesQueryResult(employeesDto);
		}
	}
}
