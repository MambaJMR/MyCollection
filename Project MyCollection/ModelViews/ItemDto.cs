using ItransitionMVC.Models.Collection;
using ItransitionMVC.Models.Item;
using System.ComponentModel.DataAnnotations;

namespace ItransitionMVC.ModelViews
{
    public class ItemDto
    {
        
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public Guid CollectionId { get; set; }
        public string UserId { get; set; }
        public List<Like> Likes {  get; set; } = new List<Like>();
        public List<string> Tags { get; set; } = new List<string>();
        public List<string> StrValue {  get; set; } = new List<string>();
        public List<int> IntValue { get; set; } = new List<int>();
        public List<bool> BoolValue { get; set; } = new List<bool>();
        public List<DateTime> DateValue { get; set; } = new List<DateTime>();
    }
}
