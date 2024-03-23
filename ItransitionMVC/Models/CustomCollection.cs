using Microsoft.AspNetCore.DataProtection.KeyManagement;
using ProjectItransition.Models.CollectionModels;
using System.ComponentModel.DataAnnotations;

namespace ItransitionMVC.Models
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
        public List<CustomCollectionItem> Items { get; set; }
        public TypeCollection typeCollection { get; set; }
    }
}
