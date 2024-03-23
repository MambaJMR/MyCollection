using ProjectItransition.Models.CollectionModels;
using System.ComponentModel.DataAnnotations;

namespace ItransitionMVC.ModelViews
{
    public class CollectionDTO
    {
        public Guid Id { get; set; }
        [Required]
        public string Name {  get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public TypeCollection typeCollection { get; set; }
        [Required]
        public IFormFile file { get; set; }
    }
}
