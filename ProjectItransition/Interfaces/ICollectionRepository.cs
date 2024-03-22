using ProjectItransition.Dto;
using ProjectItransition.Models.CollectionModels;

namespace ProjectItransition.Interfaces
{
    public interface ICollectionRepository
    {
        Task<Collect> Create(CollectionDto collect);
        Task<int> Delete(int id);
        Task<Collect> GetById(int id);
        Task<List<Collect>> Get();
        Task<int> UpDate(int id, string name, string description, string url);
    }
}