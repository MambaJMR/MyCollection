using ItransitionMVC.Models;
using ItransitionMVC.ModelViews;

namespace ItransitionMVC.Interfaces
{
    public interface ICollectionItemRepository
    {
        Task<CustomCollectionItem> Create(ItemDto item);
        Task<int> Delete(int id);
        Task<List<CustomCollectionItem>> Get();
        Task<CustomCollectionItem> GetById(int id);
        Task<int> UpDate(CustomCollectionItem item);
    }
}