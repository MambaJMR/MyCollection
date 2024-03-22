using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectItransition.Models.CollectionModels;

namespace ProjectItransition.Configurations
{
    public class CollectConfiguration : IEntityTypeConfiguration<Collect>
    {
        public void Configure(EntityTypeBuilder<Collect> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasMany(c => c.Items)
                .WithOne(i => i.Collect)
                .HasForeignKey(i => i.CollectionId);
        }
    }
}
