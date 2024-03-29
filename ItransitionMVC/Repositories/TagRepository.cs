using ItransitionMVC.Code.DataBase;
using ItransitionMVC.Interfaces;
using ItransitionMVC.Models.Item;
using Microsoft.EntityFrameworkCore;

namespace ItransitionMVC.Repositories
{

    public class TagRepository : ITagRepository
    {
        readonly ApplicationDbContext _dbContext;
        public TagRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Tag> CreateTags(string tag, Guid id)
        {
            var newTag = new Tag
            {
                ItemId = id,
                Name = tag
            };
            await  _dbContext.AddAsync(newTag);
            await  _dbContext.SaveChangesAsync();
            return newTag;
        }

        public async Task<List<Tag>> GetAll()
        {
            return await _dbContext.Tags.AsNoTracking().ToListAsync();
        }
    }
}
