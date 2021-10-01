using OrgStructure.Contracts.Common;
using Ardalis.GuardClauses;

namespace OrgStructure.Contracts.GetEmployeeById
{
	public sealed class GetEmployeeByIdQueryResult
	{
		public GetEmployeeByIdQueryResult(EmployeeDto employee)
		{
			Employee = Guard.Against.Null(employee, nameof(employee));
		}

		public EmployeeDto Employee { get; }
	}
}
