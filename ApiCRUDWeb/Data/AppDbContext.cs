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
			options.UseNpgsql("Server=dpg-cpn5ra08fa8c73arhst0-a.oregon-postgres.render.com;Port=5432;Database=apicrudweb;Userid=ericdev;Password=bP4inDUxcLyqIAQuBnbUjSrK5tq83u7N;SSL Mode=Require;");
			base.OnConfiguring(options);
		}
	}
}
