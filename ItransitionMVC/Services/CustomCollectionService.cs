using ItransitionMVC.Interfaces.ICollection;
using ItransitionMVC.Models.Collection;
using ItransitionMVC.Models.Item;
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

        public async Task<IEnumerable<CustomCollection>> GetCollections()
        {
             return  await _repository.Get();
        }
            
        public async Task<List<CustomCollection>> GetUserCollections(string userId)
        {
            return await _repository.GetUserCollections(userId);
        }
            
        
        public async Task<CustomCollection> GetCollectionById(Guid id) =>
            await _repository.GetById(id);

        public async Task<CustomCollection> CreateCustomCollection(string userId,CollectionDTO customCollection)
        {
            var imageUrl = _upLoadImage.UploadImage(customCollection.file);
            return await _repository.Create(userId, customCollection, imageUrl);
        }

        public async Task<int> UpdateCustomCollection(CollectionDTO collection)
        {
            
            return await _repository.UpDate(collection);
        }

        public async Task<Guid> DeleteCustomCollection(Guid id)
        {
            return await _repository.Delete(id);
        }
    }
}
