namespace ItransitionMVC.ModelViews
{
    public class ItemDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CollectionId { get; set; }
        public string? Tags { get; set; }
    }
}
