using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OrgStructure.Abstractions;
using OrgStructure.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace OrgStructure.Services
{
	public sealed class JsonEmployeeRepository : IEmployeeRepository
	{
		public JsonEmployeeRepository()
		{
			var employeeJson = File.ReadAllText("employees.json");
			Employees = JsonConvert
				.DeserializeObject<IEnumerable<Employee>>(
					employeeJson,
					new JsonSerializerSettings
					{
						ContractResolver = new DefaultContractResolver
						{
							NamingStrategy = new CamelCaseNamingStrategy()
						},
						Formatting = Formatting.Indented
					})
				.ToDictionary(x => x.Id, x => x);
		}

		private IDictionary<string, Employee> Employees { get; }

		public Task<Employee> GetEmployeeByIdAsync(string id)
		{
			if (Employees.TryGetValue(id, out var employee))
			{
				return Task.FromResult(employee);
			}

			return Task.FromResult(new Employee());
		}

		public Task<IEnumerable<Employee>> GetEmployeesAsync()
		{
			return Task.FromResult<IEnumerable<Employee>>(Employees.Values);
		}
	}
}
