using ItransitionMVC.Models.Item;

namespace ItransitionMVC.Interfaces
{
    public interface ICommentsService
    {
        public Task AddComment(Comment comment);
    }
}