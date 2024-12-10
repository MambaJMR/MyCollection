using ItransitionMVC.Models.Collection;
using ItransitionMVC.Models.Item;
using ItransitionMVC.ModelViews;

namespace ItransitionMVC.Interfaces.ICollection
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