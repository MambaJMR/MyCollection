using Microsoft.EntityFrameworkCore;
using ProjectItransition.Configurations;
using ProjectItransition.Models.CollectionModels;

namespace ProjectItransition.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=dpg-cnjkaoun7f5s73f9t1m0-a.oregon-postgres.render.com;Port=5432;Database=project_itransition_db;Username=artem;Password=bqGvzOXb72bnrjrzS1gKLqX81YKTbrEN");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CollectConfiguration());
            modelBuilder.ApplyConfiguration(new ItemCollectionConfiguration());
            base.OnModelCreating(modelBuilder);
        }
       
        public DbSet<Collect> Collections { get; set; }
        public DbSet<CollectionItem> CollectionItems { get; set; }

    }
}
