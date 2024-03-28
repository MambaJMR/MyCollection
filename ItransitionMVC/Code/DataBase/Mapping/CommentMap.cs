using ItransitionMVC.Models.Item;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItransitionMVC.Code.DataBase.Mapping
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(i => i.CollectionItem)
                .WithMany(c => c.ItemComments)
                .HasForeignKey(i => i.ItemId);
        }
    }
}
