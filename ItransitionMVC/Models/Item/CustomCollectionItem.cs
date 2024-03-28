using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ItransitionMVC.Models.Collection;

namespace ItransitionMVC.Models.Item
{
    public class CustomCollectionItem
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public Guid CollectionId { get; set; }
        public CustomCollection Collection { get; set; }
        [Required]
        public List<Tag> ItemTags { get; set; } = new List<Tag>();
        public List<Comment>? ItemComments { get; set; } = new List<Comment>();
        public List<Like>? ItemLikes { get; set; } = new List<Like>();
        public List<string> StrValue { get; set; } = new List<string>();
        public List<int> IntValue { get; set; } = new List<int>();
        public List<bool> BoolValue { get; set; } = new List<bool>();
        public List<DateTime> DateValue { get; set; } = new List<DateTime>();
    }
}
