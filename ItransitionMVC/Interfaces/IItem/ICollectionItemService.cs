using ItransitionMVC.Models.Item;
using ItransitionMVC.ModelViews;

namespace ItransitionMVC.Interfaces.IItem
{
    public interface ICollectionItemService
    {
        Task<CustomCollectionItem> CreateItem(ItemDto collectionItem);
        Task DeleteItem(Guid id);
        Task<List<CustomCollectionItem>> GetAllItems();
        Task<CustomCollectionItem> GetItemById(Guid id);
        Task UpDateItem(CustomCollectionItem collectionItem);
    }
}