using Microsoft.EntityFrameworkCore;
using Umschlag_Backend.Core;
using Umschlag_Backend.Core.Models;
using Umschlag_Backend.Data.Configurations;
using Umschlag_Backend.Data.Seed;

namespace Umschlag_Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));

            modelBuilder.Entity<Person>().HasKey(x => x.Id);
            modelBuilder.Entity<Person>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<Person>().Property(x => x.Name).HasMaxLength(100);
            modelBuilder.Entity<Person>().Property(x => x.Surname).HasMaxLength(100);
        }
    }
}