using System.Collections.Generic;
using System.Threading.Tasks;
using OrgStructure.Entities;

namespace OrgStructure.Abstractions
{
	public interface IEmployeeRepository
	{
		public Task<Employee> GetEmployeeByIdAsync(string id);

		public Task<IEnumerable<Employee>> GetEmployeesAsync();
	}
}
