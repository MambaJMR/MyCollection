using ItransitionMVC.Models.Item;

namespace ItransitionMVC.Interfaces.ICommentsAndLike
{
    public interface ICommentsRepository
    {
        public Task CreateComment(Comment comment);
    }
}