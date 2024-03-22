using ProjectItransition.Dto;
using ProjectItransition.Interfaces;
using ProjectItransition.Models.CollectionModels;

namespace ProjectItransition.Services
{
    public class CollectionService : ICollectionService
    {
        public readonly ICollectionRepository _collectionRepository;
        public CollectionService(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        public async Task<Collect> GetCollectById(int id)
        {
            return await _collectionRepository.GetById(id);
        }
        public async Task<List<Collect>> GetAllCollects()
        {
            return await _collectionRepository.Get();
        }

        public async Task<Collect> CreateCollect(CollectionDto collect)
        {
            return await _collectionRepository.Create(collect);
        }

        public async Task<int> UpDateCollect(int id, string name, string description, string url)
        {
            return await _collectionRepository.UpDate(id, name, description, url);
        }

        public async Task<int> DeleteCollect(int id)
        {
            return await _collectionRepository.Delete(id);
        }
    }
}
