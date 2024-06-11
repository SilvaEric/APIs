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
			options.UseSqlite("DataSource=app.db;");
			base.OnConfiguring(options);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Pet>()
				.HasOne(e => e.Details)
				.WithOne(e => e.Pet)
				.HasForeignKey<PetDetails>(e => e.PetId)
				.IsRequired(false);

			modelBuilder.Entity<User>()
				.HasMany(e => e.Pets)
				.WithOne(e => e.Tutor)
				.HasForeignKey(e => e.TutorId)
				.IsRequired(false);

			base.OnModelCreating(modelBuilder);
		}
	}
}
