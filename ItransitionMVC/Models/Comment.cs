using System.ComponentModel.DataAnnotations;

namespace ItransitionMVC.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CommentValue { get; set; }
        public DateTime CommentCreateDate { get; set; }
        public CustomCollectionItem CollectionItem { get; set; }
    }
}
