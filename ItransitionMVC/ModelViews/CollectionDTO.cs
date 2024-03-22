using ProjectItransition.Models.CollectionModels;
using System.ComponentModel.DataAnnotations;

namespace ItransitionMVC.ModelViews
{
    public class CollectionDTO
    {
        public int Id { get; set; }
        public string Name {  get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TypeCollection typeCollection { get; set; }
        public IFormFile file { get; set; }
    }
}
