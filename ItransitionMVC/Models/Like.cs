using ItransitionMVC.Models;

namespace ItransitionMVC.Models
{
    public class Like
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Guid ItemId { get; set; }
        public CustomCollectionItem CollectionItem { get; set; }

    }
}
