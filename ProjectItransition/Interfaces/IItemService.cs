using ProjectItransition.Dto;
using ProjectItransition.Models.CollectionModels;

namespace ProjectItransition.Interfaces
{
    public interface IItemService
    {
        Task<CollectionItem> CreateItem(CollectionItemDto collectionItem);
        Task<int> DeleteItem(int id);
        Task<List<CollectionItem>> GetAllItems();
        Task<CollectionItem> GetItemById(int id);
        Task<int> UpDateItem(CollectionItemDto collectionItem);
    }
}