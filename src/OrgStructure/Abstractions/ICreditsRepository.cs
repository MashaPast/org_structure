using System.Collections.Generic;
using System.Threading.Tasks;
using OrgStructure.Entities;

namespace OrgStructure.Abstractions
{
	public interface ICreditsRepository
	{
		public Task<IEnumerable<Credit>> GetCreditsAsync();
	}
}
