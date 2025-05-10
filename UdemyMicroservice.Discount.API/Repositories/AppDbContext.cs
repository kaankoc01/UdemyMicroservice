using MongoDB.Driver;
using System.Reflection;


namespace UdemyMicroservice.Discount.API.Repositories
{
    public class AppDbContext(DbContextOptions options): DbContext(options)
    {
        public DbSet<DiscountEntity> DiscountEntities { get; set; } = null!;


		public static AppDbContext Create(IMongoDatabase database)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName);

            return  new AppDbContext(optionsBuilder.Options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
