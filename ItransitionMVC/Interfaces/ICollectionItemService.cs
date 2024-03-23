using ItransitionMVC.Models;
using ItransitionMVC.ModelViews;

namespace ItransitionMVC.Interfaces
{
    public interface ICollectionItemService
    {
        Task<CustomCollectionItem> CreateItem(ItemDto collectionItem);
        Task<Guid> DeleteItem(Guid id);
        Task<List<CustomCollectionItem>> GetAllItems();
        Task<CustomCollectionItem> GetItemById(Guid id);
        Task<int> UpDateItem(CustomCollectionItem collectionItem);
    }
}