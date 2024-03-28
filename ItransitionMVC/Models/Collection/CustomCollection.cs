using ItransitionMVC.Models.Elements;
using ItransitionMVC.Models.Item;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.ComponentModel.DataAnnotations;

namespace ItransitionMVC.Models.Collection
{
    public class CustomCollection
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string UserName { get; set; }
        public List<CustomCollectionItem> Items { get; set; } = new List<CustomCollectionItem>();
        public TypeCollection typeCollection { get; set; }
        public List<ElementString>? ItemElements { get; set; } = new List<ElementString>();
        public List<ElementInt>? ItemIntElements { get; set; } = new List<ElementInt>();
        public List<ElementBool>? ItemBoolElements { get; set; } = new List<ElementBool>();
        public List<ElementDate>? ItemDateElements { get; set; } = new List<ElementDate>();
    }
}
