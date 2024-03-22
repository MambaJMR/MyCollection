using ProjectItransition.Dto;
using ProjectItransition.Models.CollectionModels;

namespace ProjectItransition.Interfaces
{
    public interface ICollectionService
    {
        Task<Collect> CreateCollect(CollectionDto collect);
        Task<int> DeleteCollect(int id);
        Task<List<Collect>> GetAllCollects();
        Task<Collect> GetCollectById(int id);
        Task<int> UpDateCollect(int id, string name, string description, string url);
    }
}