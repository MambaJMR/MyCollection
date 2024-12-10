using ItransitionMVC.Models.Collection;
using ItransitionMVC.Models.Item;

namespace ItransitionMVC.ModelViews
{
    public class IndexViewModel
    {
        public IEnumerable<CustomCollection> Collections { get; set; }
        public IEnumerable<CustomCollectionItem> CollectionItems { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}
