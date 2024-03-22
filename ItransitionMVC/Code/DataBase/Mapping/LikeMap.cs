using ItransitionMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItransitionMVC.Code.DataBase.Mapping
{
    public class LikeMap : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(i => i.CollectionItem)
                .WithMany(c => c.Likes)
                .HasForeignKey(i => i.ItemId);
        }
    }
}
