using ItransitionMVC.Models.Item;
using ItransitionMVC.ModelViews;

namespace ItransitionMVC.Interfaces.IItem
{
    public interface ICollectionItemRepository
    {
        Task<CustomCollectionItem> Create(ItemDto item);
        Task Delete(Guid id);
        Task<List<CustomCollectionItem>> Get();
        Task<CustomCollectionItem> GetById(Guid id);
        Task UpDate(CustomCollectionItem item);
    }
}