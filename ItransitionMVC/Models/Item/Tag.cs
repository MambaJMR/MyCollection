namespace ItransitionMVC.Models.Item
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ItemId { get; set; }
        public CustomCollectionItem Item { get; set; }
    }
}
