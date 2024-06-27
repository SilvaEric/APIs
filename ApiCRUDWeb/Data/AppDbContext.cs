using ApiCRUDWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCRUDWeb.Data
{
	public class AppDbContext : DbContext
	{
        public DbSet<Pet> Pets { get; set; }
		public DbSet<Institution> Institutions { get; set; }
		public DbSet<Owner> Owners { get; set; }
		public DbSet<PetDetails> PetsDetails { get; set; }
        public DbSet<User> Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{

			options.UseNpgsql(Environment.GetEnvironmentVariable("PostgresSql"));
			base.OnConfiguring(options);
		}
	}
}
