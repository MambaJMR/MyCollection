using ProjectItransition.Dto;
using ProjectItransition.Interfaces;
using ProjectItransition.Models.CollectionModels;
using System.Runtime.CompilerServices;

namespace ProjectItransition.Services
{
    public class ItemService : IItemService
    {
        private readonly ICollectionItemRepository _itemRepository;
        public ItemService(ICollectionItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<CollectionItem> GetItemById(int id)
        {
            return await _itemRepository.GetById(id);
        }

        public async Task<List<CollectionItem>> GetAllItems()
        {
            return await _itemRepository.Get();
        }

        public async Task<CollectionItem> CreateItem(CollectionItemDto collectionItem)
        {
            return await _itemRepository.Create(collectionItem);
        }

        public async Task<int> UpDateItem(CollectionItemDto collectionItem)
        {
            return await _itemRepository.UpDate(collectionItem.Id, collectionItem.Name, collectionItem.Description, collectionItem.Tags);
        }

        public async Task<int> DeleteItem(int id)
        {
            return await _itemRepository.Delete(id);
        }
    }
}
