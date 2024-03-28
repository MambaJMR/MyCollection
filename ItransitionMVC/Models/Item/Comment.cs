using System.ComponentModel.DataAnnotations;

namespace ItransitionMVC.Models.Item
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string CommentValue { get; set; }
        public DateTime CommentCreateDate { get; set; }
        public Guid ItemId { get; set; }
        public CustomCollectionItem? CollectionItem { get; set; }
    }
}
