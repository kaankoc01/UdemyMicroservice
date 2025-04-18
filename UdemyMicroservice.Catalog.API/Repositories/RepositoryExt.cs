using MongoDB.Driver;
using UdemyMicroservice.Catalog.API.Options;

namespace UdemyMicroservice.Catalog.API.Repositories
{
    public static class RepositoryExt
    {
        public static IServiceCollection AddDatabaseServiceExt(this IServiceCollection services)
        {
            services.AddSingleton<IMongoClient, MongoClient>(sp =>
            {
                var options = sp.GetRequiredService<MongoOption>();
                return new MongoClient(options.ConnectionString);
            });

            services.AddScoped(sp =>
            {
                var mongoClient = sp.GetRequiredService<IMongoClient>();
                var options = sp.GetRequiredService<MongoOption>();
                var database = mongoClient.GetDatabase(options.DatabaseName);
                return AppDbContext.Create(database);
            });

            return services;
        }
    }
}
