using ItransitionMVC.Models.Elements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItransitionMVC.Code.DataBase.Mapping
{
    public class StringElementMap : IEntityTypeConfiguration<ElementString>
    {
        public void Configure(EntityTypeBuilder<ElementString> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasOne(i => i.Collection)
                .WithMany(c => c.ItemElements)
                .HasForeignKey(i => i.CollectionId);
        }
    }
}
