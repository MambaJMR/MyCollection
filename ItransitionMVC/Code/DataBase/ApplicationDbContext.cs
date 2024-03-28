using ItransitionMVC.Code.DataBase.Mapping;
using ItransitionMVC.Models;
using ItransitionMVC.Models.Collection;
using ItransitionMVC.Models.Elements;
using ItransitionMVC.Models.Item;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ItransitionMVC.Code.DataBase
{
    public class ApplicationDbContext : IdentityDbContext<CustomUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomCollectionMap());
            modelBuilder.ApplyConfiguration(new CustomCollectionItemMap());
            modelBuilder.ApplyConfiguration(new LikeMap());
            modelBuilder.ApplyConfiguration(new StringElementMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new TagMap());
            base.OnModelCreating(modelBuilder);
        }
       
        public DbSet<CustomCollection> Collections { get; set; }
        public DbSet<CustomCollectionItem> CollectionItems { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ElementString> StringElements { get; set; }
        public DbSet<ElementInt> IntElements { get; set; }
        public DbSet<ElementBool> BoolElements { get; set; }
        public DbSet<ElementDate> DateElements { get; set; }

    }
}
