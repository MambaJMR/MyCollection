using ItransitionMVC.Models.Collection;

namespace ItransitionMVC.Models.Elements
{
    public class ElementInt
    {
        public Guid Id { get; set; }
        public string IntName { get; set; }
        public Guid CollectionId { get; set; }
        public CustomCollection Collection { get; set; }
    }
}
