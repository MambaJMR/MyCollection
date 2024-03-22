using ItransitionMVC.Interfaces;
using ItransitionMVC.Models;
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
        public async Task<CustomCollectionItem> GetItemById(int id)
        {
            return await _itemRepository.GetById(id);
        }

        public async Task<List<CustomCollectionItem>> GetAllItems()
        {
            return await _itemRepository.Get();
        }

        public async Task<CustomCollectionItem> CreateItem(ItemDto collectionItem)
        {
            return await _itemRepository.Create(collectionItem);
        }

        public async Task<int> UpDateItem(CustomCollectionItem collectionItem)
        {
            return await _itemRepository.UpDate(collectionItem);
        }

        public async Task<int> DeleteItem(int id)
        {
            return await _itemRepository.Delete(id);
        }
    }
}
