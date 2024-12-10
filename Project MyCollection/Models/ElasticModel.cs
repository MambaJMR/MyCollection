using ItransitionMVC.Models.Elements;
using ItransitionMVC.Models.Item;

namespace ItransitionMVC.Models
{
    public class ElasticModel
    {
        public string NameItem { get; set; } = string.Empty;
        public string NameCollection { get; set; } = string.Empty;
        public string DescriptionItem { get; set; } = string.Empty;
        public string DescriptionCollection { get; set; } = string.Empty;
        public Guid ItemId { get; set; }
        public Guid CollectionId { get; set; }
        public string? Comments { get; set; }
        public string? StrElements { get; set; }
        public string? IntElements { get; set; }
        public string? BoolElements { get; set; }
        public string? DateElements { get; set; }
        public string? Tags { get; set; }
        public List<string>? StrValue {  get; set; }

    }
}
