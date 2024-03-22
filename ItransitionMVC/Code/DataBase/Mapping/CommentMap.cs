using ItransitionMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Dropbox.Api.TeamLog.EventCategory;

namespace ItransitionMVC.Code.DataBase.Mapping
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(i => i.CollectionItem)
                .WithMany(c => c.Comments)
                .HasForeignKey(i => i.ItemId);
        }
    }
}
