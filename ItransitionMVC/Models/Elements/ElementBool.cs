using ItransitionMVC.Models.Collection;

namespace ItransitionMVC.Models.Elements
{
    public class ElementBool
    {
        public Guid Id { get; set; }
        public string BoolName { get; set; }
        public Guid CollectionId { get; set; }
        public CustomCollection Collection { get; set; }
    }
}
