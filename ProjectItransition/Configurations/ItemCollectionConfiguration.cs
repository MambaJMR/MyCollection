using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectItransition.Models.CollectionModels;

namespace ProjectItransition.Configurations
{
    public class ItemCollectionConfiguration : IEntityTypeConfiguration<CollectionItem>
    {
        public void Configure(EntityTypeBuilder<CollectionItem> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne(i => i.Collect)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.CollectionId);
                
        }
    }
}
