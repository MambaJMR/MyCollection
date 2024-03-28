using ItransitionMVC.Code.DataBase;
using ItransitionMVC.Interfaces;
using ItransitionMVC.Models.Item;

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

            return newTag;
        }
    }
}
