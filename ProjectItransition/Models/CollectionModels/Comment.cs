using System.ComponentModel.DataAnnotations;

namespace ProjectItransition.Models.CollectionModels
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CommentValue { get; set; }
        public DateTime CommentCreateDate { get; set; }
        public CollectionItem CollectionItem { get; set; }
    }
}
