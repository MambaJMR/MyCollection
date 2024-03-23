using Microsoft.AspNetCore.DataProtection.KeyManagement;
using ProjectItransition.Models.CollectionModels;

namespace ItransitionMVC.Models
{
    public class CustomCollection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<CustomCollectionItem> Items { get; set; }
        public TypeCollection typeCollection { get; set; }
    }
}
