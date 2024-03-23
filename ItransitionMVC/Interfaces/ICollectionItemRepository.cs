using ItransitionMVC.Models;
using ItransitionMVC.ModelViews;

namespace ItransitionMVC.Interfaces
{
    public interface ICollectionItemRepository
    {
        Task<CustomCollectionItem> Create(ItemDto item);
        Task<Guid> Delete(Guid id);
        Task<List<CustomCollectionItem>> Get();
        Task<CustomCollectionItem> GetById(Guid id);
        Task<int> UpDate(CustomCollectionItem item);
    }
}