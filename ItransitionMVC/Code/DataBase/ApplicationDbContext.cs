using ItransitionMVC.Code.DataBase.Mapping;
using ItransitionMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ItransitionMVC.Code.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomCollectionMap());
            modelBuilder.ApplyConfiguration(new CustomCollectionItemMap());
            base.OnModelCreating(modelBuilder);
        }
       
        public DbSet<CustomCollection> Collections { get; set; }
        public DbSet<CustomCollectionItem> CollectionItems { get; set; }

    }
}
