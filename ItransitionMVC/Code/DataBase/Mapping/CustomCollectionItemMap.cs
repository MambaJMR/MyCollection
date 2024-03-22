using ItransitionMVC.Models;
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
                
        }
    }
}
