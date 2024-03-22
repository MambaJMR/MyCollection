using ProjectItransition.Dto;
using ProjectItransition.Models.CollectionModels;

namespace ProjectItransition.Interfaces
{
    public interface ICollectionItemRepository
    {
        Task<CollectionItem> Create(CollectionItemDto item);
        Task<int> Delete(int id);
        Task<CollectionItem> GetById(int id);
        Task<List<CollectionItem>> Get();
        Task<int> UpDate(int id, string name, string description, string[] tags);
    }
}