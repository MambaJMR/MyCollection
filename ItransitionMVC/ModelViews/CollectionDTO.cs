using ItransitionMVC.Models.Collection;
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
        [Required]
        public IFormFile file { get; set; }
        public TypeCollection typeCollection { get; set; }
        public string[]? ElementName { get; set; }
        public string[]? IntName { get; set; }
        public string[]? BoolName { get; set; }
        public string[]? DateName { get; set; }
        public string userId { get; set; }
    }
}
