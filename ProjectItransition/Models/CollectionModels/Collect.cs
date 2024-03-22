namespace ProjectItransition.Models.CollectionModels
{
    public class Collect
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<CollectionItem> Items { get; set; }
        public TypeCollection typeCollection { get; set; }
    }
}
