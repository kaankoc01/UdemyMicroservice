﻿using MongoDB.Driver;
using System.Reflection;
using UdemyMicroservice.Catalog.API.Features.Categories;
using UdemyMicroservice.Catalog.API.Features.Courses;

namespace UdemyMicroservice.Catalog.API.Repositories
{
    public class AppDbContext(DbContextOptions options): DbContext(options)
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }


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
