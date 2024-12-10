using ItransitionMVC.Models.Item;

namespace ItransitionMVC.Interfaces.ICommentsAndLike
{
    public interface ILikeRepository
    {
        //void CreateLike(string userId, CustomCollectionItem itemId);
        //Task RemoveLike(Like like);

        public void CreateLike(Like like);
        public void RemoveLike(Like like);
    }
}