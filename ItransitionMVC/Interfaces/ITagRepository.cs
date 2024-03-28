using ItransitionMVC.Models.Item;

namespace ItransitionMVC.Interfaces
{
    public interface ITagRepository
    {
       public Task<Tag> CreateTags(string tag, Guid id);
    }
}