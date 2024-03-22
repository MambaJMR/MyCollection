namespace ItransitionMVC.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ItemId { get; set; }
        public CustomCollectionItem Item { get; set; }
    }
}
