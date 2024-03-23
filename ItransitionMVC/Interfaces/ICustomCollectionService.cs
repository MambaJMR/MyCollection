using ItransitionMVC.Models;
using ItransitionMVC.ModelViews;

namespace ItransitionMVC.Interfaces
{
    public interface ICustomCollectionService
    {
        Task<CustomCollection> CreateCustomCollection(string userId, CollectionDTO customCollection);
        Task<Guid> DeleteCustomCollection(Guid id);
        Task<CustomCollection> GetCollectionById(Guid id);
        Task<List<CustomCollection>> GetUserCollections(string userId);
        Task<List<CustomCollection>> GetCollections();
        Task<int> UpdateCustomCollection(CollectionDTO collection);
    }
}