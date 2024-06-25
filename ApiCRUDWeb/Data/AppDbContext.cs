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
<<<<<<< HEAD
			var connectionstring =  
			options.UseNpgsql(_configuration.GetConnectionString("PostgresSql"));
=======
			options.UseNpgsql("Server=dpg-cpn5ra08fa8c73arhst0-a;Port=5432;Database=apicrudweb;Userid=ericdev;Password=bP4inDUxcLyqIAQuBnbUjSrK5tq83u7N;");
>>>>>>> 8f0ebd4354193af45f3a991a1d9156087b096352
			base.OnConfiguring(options);
		}
	}
}
