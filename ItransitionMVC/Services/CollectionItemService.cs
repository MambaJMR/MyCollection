using ItransitionMVC.Interfaces.IItem;
using ItransitionMVC.Models.Item;
using ItransitionMVC.ModelViews;

namespace ItransitionMVC.Services
{
    public class CollectionItemService : ICollectionItemService
    {
        readonly ICollectionItemRepository _itemRepository;
        public CollectionItemService(ICollectionItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<CustomCollectionItem> GetItemById(Guid id)
        {
            return await _itemRepository.GetById(id);
        }

        public async Task<IEnumerable<CustomCollectionItem>> GetAllItems()
        {
            return await _itemRepository.Get();
        }

        public async Task<CustomCollectionItem> CreateItem(ItemDto collectionItem)
        {
            return await _itemRepository.Create(collectionItem);
        }

        public async Task UpDateItem(CustomCollectionItem collectionItem)
        {
             await _itemRepository.UpDate(collectionItem);
        }

        public async Task DeleteItem(Guid id)
        {
            await _itemRepository.Delete(id);
        }
    }
}
