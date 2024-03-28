using ItransitionMVC.Models.Collection;

namespace ItransitionMVC.Models.Elements
{
    public class ElementDate
    {
        public Guid Id { get; set; }
        public string DateName { get; set; }
        public Guid CollectionId { get; set; }
        public CustomCollection Collection { get; set; }
    }
}
