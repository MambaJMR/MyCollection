using ItransitionMVC.Code.DataBase;
using ItransitionMVC.Interfaces;
using ItransitionMVC.Interfaces.ICommentsAndLike;
using ItransitionMVC.Models.Item;
using ItransitionMVC.Services;
using Microsoft.EntityFrameworkCore;

namespace ItransitionMVC.Repositories.LikeAndComments
{
    public class CommentsRepository : ICommentsRepository
    {
        readonly ApplicationDbContext _dbContext;
        public CommentsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateComment(Comment comment)
        {
            await _dbContext.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
