using System.Collections.Generic;
using OrgStructure.Contracts.Common;
using Ardalis.GuardClauses;

namespace OrgStructure.Contracts.GetEmployees
{
	public sealed class GetEmployeesQueryResult
	{
		public GetEmployeesQueryResult(IEnumerable<EmployeeDto> employees)
		{
			Employees = Guard.Against.Null(employees, nameof(employees));
		}

		public IEnumerable<EmployeeDto> Employees { get; }
	}
}
