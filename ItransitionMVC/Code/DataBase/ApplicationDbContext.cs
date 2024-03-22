using ItransitionMVC.Code.DataBase.Mapping;
using ItransitionMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ItransitionMVC.Code.DataBase
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomCollectionMap());
            modelBuilder.ApplyConfiguration(new CustomCollectionItemMap());
            modelBuilder.ApplyConfiguration(new LikeMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new TagMap());
            base.OnModelCreating(modelBuilder);
        }
       
        public DbSet<CustomCollection> Collections { get; set; }
        public DbSet<CustomCollectionItem> CollectionItems { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
