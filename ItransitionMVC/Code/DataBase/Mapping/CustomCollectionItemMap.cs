using ItransitionMVC.Models.Item;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ItransitionMVC.Code.DataBase.Mapping
{
    public class CustomCollectionItemMap : IEntityTypeConfiguration<CustomCollectionItem>
    {
        public void Configure(EntityTypeBuilder<CustomCollectionItem> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne(i => i.Collection)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.CollectionId);

            builder.HasMany(c => c.ItemLikes)
               .WithOne(i => i.CollectionItem)
               .HasForeignKey(i => i.ItemId);

            builder.HasMany(c => c.ItemComments)
               .WithOne(i => i.CollectionItem)
               .HasForeignKey(i => i.ItemId);

            builder.HasMany(c => c.ItemTags)
               .WithOne(i => i.Item)
               .HasForeignKey(i => i.ItemId);

            //builder.HasMany(c => c.stringElements)
            //   .WithOne(i => i.Item)
            //   .HasForeignKey(i => i.ItemId);

        }
    }
}
