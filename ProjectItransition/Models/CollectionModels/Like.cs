namespace ProjectItransition.Models.CollectionModels
{
    public class Like
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LikeCount { get; set; }
        public CollectionItem collectionItem { get; set; }

    }
}
