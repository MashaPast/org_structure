using System.Text.Json;
using OrgStructure.Abstractions;
using OrgStructure.Services;
using OrgStructure.Web.AutoMapperProperties;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace OrgStructure.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton(
				new MapperConfiguration(
					mc => mc.AddProfile(new EmployeeControllerProfile()))
				.CreateMapper());

			services.AddScoped<IEmployeeRepository, JsonEmployeeRepository>();

			services
				.AddControllers()
				.AddJsonOptions(options =>
				{
					options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
					options.JsonSerializerOptions.IgnoreNullValues = true;
					options.JsonSerializerOptions.AllowTrailingCommas = false;
				});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints => endpoints.MapControllers());
		}
	}
}
