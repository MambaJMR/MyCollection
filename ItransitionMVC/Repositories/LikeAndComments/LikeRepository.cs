using ItransitionMVC.Code.DataBase;
using ItransitionMVC.Interfaces.ICommentsAndLike;
using ItransitionMVC.Models.Item;

namespace ItransitionMVC.Repositories.LikeAndComments
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public LikeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateLike(Like like)
        {
            _dbContext.Likes.Add(like);
            _dbContext.SaveChanges();
        }

        public void RemoveLike(Like like)
        {
            _dbContext.Likes.Remove(like);
            _dbContext.SaveChanges();
        }
        //public void CreateLike(string userId, CustomCollectionItem ItemId)
        //{
        //    var _like = new Like
        //    {
        //        ItemId = ItemId.Id,
        //        UserId = userId,
        //    };
        //    _dbContext.Likes.Add(_like);
        //    _dbContext.SaveChanges();
        //}

        //public async Task RemoveLike(Like like)
        //{
        //     //_dbContext.Likes.Remove(like);
        //    await _dbContext.Likes.Where(i => i.Id == like.Id).ExecuteDeleteAsync();
        //    await _dbContext.SaveChangesAsync();

        //}
    }
}
