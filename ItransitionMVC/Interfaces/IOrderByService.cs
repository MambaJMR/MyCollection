using ItransitionMVC.ModelViews;

namespace ItransitionMVC.Interfaces
{
    public interface IOrderByService
    {
        Task<IndexViewModel> OrderByHomeIndex();
    }
}