using System.ComponentModel.DataAnnotations;

namespace ItransitionMVC.ModelViews
{
    public class ItemDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public Guid CollectionId { get; set; }
        [Required]
        public string Tags { get; set; }
    }
}
