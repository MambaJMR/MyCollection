using ProjectItransition.Models.CollectionModels;

namespace ProjectItransition.Dto
{
    public class CollectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public TypeCollection typeCollection { get; set; }

    }
         
    
}
