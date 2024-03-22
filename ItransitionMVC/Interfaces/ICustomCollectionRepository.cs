using ItransitionMVC.Models;
using ItransitionMVC.ModelViews;

namespace ItransitionMVC.Interfaces
{
    public interface ICustomCollectionRepository
    {
        Task<CustomCollection> Create(CollectionDTO collect, string image);
        Task<List<CustomCollection>> Get();
        Task<CustomCollection> GetById(int id);
        Task<int> UpDate(CollectionDTO customCollection);
        Task<int> Delete(int id);
    }
}