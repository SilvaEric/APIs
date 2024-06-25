using ApiCRUDWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCRUDWeb.Data
{
	public class AppDbContext : DbContext
	{
		private readonly IConfiguration _configuration;
        public DbSet<Pet> Pets { get; set; }
		public DbSet<Institution> Institutions { get; set; }
		public DbSet<Owner> Owners { get; set; }
		public DbSet<PetDetails> PetsDetails { get; set; }
        public DbSet<User> Users { get; set; }

		public AppDbContext(IConfiguration Configuration)
		{
			_configuration = Configuration;
		}
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			var connectionstring =  
			options.UseNpgsql(_configuration.GetConnectionString("PostgresSql"));
			base.OnConfiguring(options);
		}
	}
}
