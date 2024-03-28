using ItransitionMVC.Models.Collection;

namespace ItransitionMVC.Models.Elements
{
    public class ElementString
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CollectionId { get; set; }
        public CustomCollection Collection { get; set; }
    }
}
