using ItransitionMVC.Interfaces;
using ItransitionMVC.Models;
using ItransitionMVC.ModelViews;

namespace ItransitionMVC.Services
{
    public class CustomCollectionService : ICustomCollectionService
    {
        private readonly ICustomCollectionRepository _repository;
        readonly UpLoadImageService _upLoadImage;
        public CustomCollectionService(ICustomCollectionRepository repository, UpLoadImageService upLoadImage)
        {
            _repository = repository;
            _upLoadImage = upLoadImage;

        }

        public async Task<List<CustomCollection>> GetCollections() =>
            await _repository.Get();

        public async Task<CustomCollection> GetCollectionById(int id) =>
            await _repository.GetById(id);

        public async Task<CustomCollection> CreateCustomCollection(CollectionDTO customCollection)
        {
            var imageUrl = _upLoadImage.UploadImage(customCollection.file);
            return await _repository.Create(customCollection, imageUrl);
        }

        public async Task<int> UpdateCustomCollection(CollectionDTO collection)
        {
            
            return await _repository.UpDate(collection);
        }

        public async Task<int> DeleteCustomCollection(int id)
        {
            return await _repository.Delete(id);
        }
    }
}
