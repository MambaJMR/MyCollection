using ItransitionMVC.Models;
using ItransitionMVC.ModelViews;

namespace ItransitionMVC.Interfaces
{
    public interface ICustomCollectionRepository
    {
        Task<CustomCollection> Create(string userId, CollectionDTO collect, string image);
        Task<List<CustomCollection>> Get();
        Task<CustomCollection> GetById(Guid id);
        Task<List<CustomCollection>> GetUserCollections(string userId);
        Task<int> UpDate(CollectionDTO customCollection);
        Task<Guid> Delete(Guid id);
    }
}