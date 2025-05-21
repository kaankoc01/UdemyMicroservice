using Microsoft.EntityFrameworkCore;
using UdemyMicroservice.Order.Domain.Entity;

namespace UdemyMicroservice.Order.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
		public DbSet<Domain.Entity.Order> Orders { get; set; } = null!;
		public DbSet<OrderItem> OrderItems { get; set; } = null!;
		public DbSet<Address> Addresses { get; set; } = null!;
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersistenceAssembly).Assembly);
			base.OnModelCreating(modelBuilder);
		}
	}
}
