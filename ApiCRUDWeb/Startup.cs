using ApiCRUDWeb.Data;
using ApiCRUDWeb.Repositories.Interfaces;
using ApiCRUDWeb.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace ApiCRUDWeb
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<AppDbContext>();
			services.AddControllers()
				.AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
			}); ;
			services.AddScoped<IPetDetailsRepository, PetDetailsRepository>();
			services.AddScoped<IPetRepository, PetRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiCRUDWeb", Version = "v1" });
			});
		}
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseHttpsRedirection();
			if (env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiCRUDWeb v1"));
			}
			app.UseRouting();
			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
