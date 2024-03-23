using ItransitionMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ItransitionMVC.Code.DataBase.Mapping
{
    public class CustomCollectionMap : IEntityTypeConfiguration<CustomCollection>
    {
        public void Configure(EntityTypeBuilder<CustomCollection> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasMany(c => c.Items)
                .WithOne(i => i.Collection)
                .HasForeignKey(i => i.CollectionId);
            builder.HasOne(i => i.User)
                .WithMany(c => c.Collections)
                .HasForeignKey(i => i.UserId);
        }
    }
}
