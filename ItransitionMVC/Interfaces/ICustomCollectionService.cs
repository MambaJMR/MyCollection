using ItransitionMVC.Models;
using ItransitionMVC.ModelViews;

namespace ItransitionMVC.Interfaces
{
    public interface ICustomCollectionService
    {
        Task<CustomCollection> CreateCustomCollection(CollectionDTO customCollection);
        Task<int> DeleteCustomCollection(int id);
        Task<CustomCollection> GetCollectionById(int id);
        Task<List<CustomCollection>> GetCollections();
        Task<int> UpdateCustomCollection(CollectionDTO collection);
    }
}