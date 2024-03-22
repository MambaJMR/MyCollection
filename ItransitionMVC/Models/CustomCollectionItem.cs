using System.Text.Json.Serialization;

namespace ItransitionMVC.Models
{
    public class CustomCollectionItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int CollectionId { get; set; }
        public CustomCollection? Collection { get; set; }
        public string? Tags { get; set; }

        //public List<Comment>? Comments { get; set; }
        //public List<Like>? Like { get; set; }
    }
}
