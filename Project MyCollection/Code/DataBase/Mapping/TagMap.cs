using ItransitionMVC.Models.Item;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItransitionMVC.Code.DataBase.Mapping
{
    public class TagMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(i => i.Item)
                .WithMany(c => c.ItemTags)
                .HasForeignKey(i => i.ItemId);
        }
    }
}
