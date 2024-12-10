using ItransitionMVC.Models.Collection;
using ItransitionMVC.ModelViews;

namespace ItransitionMVC.Interfaces.ICollection
{
    public interface ICustomCollectionService
    {
        Task<CustomCollection> CreateCustomCollection(string userId, CollectionDTO customCollection);
        Task<Guid> DeleteCustomCollection(Guid id);
        Task<CustomCollection> GetCollectionById(Guid id);
        Task<List<CustomCollection>> GetUserCollections(string userId);
        Task<IEnumerable<CustomCollection>> GetCollections();
        Task<int> UpdateCustomCollection(CollectionDTO collection);
    }
}