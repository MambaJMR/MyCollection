using ItransitionMVC.Models;

namespace ItransitionMVC.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public CustomCollectionItem CollectionItem { get; set; }

    }
}
