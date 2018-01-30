using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppEFSqliteEx01.Model
{
    /// <summary>
    /// Install the following nuget packages in my project:
    ///     Microsoft.Extensions.Configuration
    ///     Microsoft.Extensions.Configuration.FileExtensions
    ///     Microsoft.Extensions.Configuration.Json
    /// </summary>
    class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductTag> ProductsTags { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        private static IConfigurationRoot _configuration;

        public StoreContext()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            _configuration = builder.Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var cnn = (_configuration.GetConnectionString("cnn"));
            optionsBuilder.UseSqlServer(cnn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many to many relationship
            modelBuilder.Entity<ProductTag>()
                .HasKey(pt => new {pt.ProductId, pt.TagId});

            // Unique keys
            modelBuilder.Entity<Client>().HasIndex(c => c.PersonId).IsUnique(true);
            modelBuilder.Entity<Employee>().HasIndex(e => e.PersonId).IsUnique(true);
            modelBuilder.Entity<Manager>().HasIndex(m => m.PersonId).IsUnique(true);
        }
    }
}
