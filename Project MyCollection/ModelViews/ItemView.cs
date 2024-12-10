using ItransitionMVC.Models.Collection;
using ItransitionMVC.Models.Elements;
using ItransitionMVC.Models.Item;

namespace ItransitionMVC.ModelViews
{
    public class ItemView
    {
        public CustomCollection Collection { get; set; }
        public CustomCollectionItem Item { get; set; }
        public string UserName { get; set; }
        public Guid ItemId { get; set; }
        public Guid CollectionId { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }
        public List<ElementString> ElementString { get; set; }
        public List<ElementInt> ElementInt { get; set; }
        public List<ElementBool> ElementBool { get; set; }
        public List<ElementDate> ElementDate { get; set; }

    }
}
