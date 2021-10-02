namespace OrgStructure.Services
{
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Threading.Tasks;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Serialization;
	using OrgStructure.Abstractions;
	using OrgStructure.Entities;

	public sealed class JsonCreditsRepository : ICreditsRepository
	{
		public JsonCreditsRepository()
		{
			var creditsJson = File.ReadAllText("credits.json");
			Credits = JsonConvert
				.DeserializeObject<IEnumerable<Credit>>(
					creditsJson,
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

		private IDictionary<string, Credit> Credits { get; }
		public Task<IEnumerable<Credit>> GetCreditsAsync()
		{
			return Task.FromResult<IEnumerable<Credit>>(Credits.Values);
		}
	}
}
