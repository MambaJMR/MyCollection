using ProjectItransition.Models.CollectionModels;

namespace ProjectItransition.Dto
{
    public class CollectionItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CollectionId { get; set; }
        public string[] Tags { get; set; }
    }
}
