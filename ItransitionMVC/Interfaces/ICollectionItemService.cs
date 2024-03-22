using ItransitionMVC.Models;
using ItransitionMVC.ModelViews;

namespace ItransitionMVC.Interfaces
{
    public interface ICollectionItemService
    {
        Task<CustomCollectionItem> CreateItem(ItemDto collectionItem);
        Task<int> DeleteItem(int id);
        Task<List<CustomCollectionItem>> GetAllItems();
        Task<CustomCollectionItem> GetItemById(int id);
        Task<int> UpDateItem(CustomCollectionItem collectionItem);
    }
}