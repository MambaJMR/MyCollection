using Microsoft.EntityFrameworkCore;
using ProjectItransition.Data;
using ProjectItransition.Dto;
using ProjectItransition.Interfaces;
using ProjectItransition.Models.CollectionModels;

namespace ProjectItransition.Repositories
{
    public class CollectionItemRepository : ICollectionItemRepository
    {
        private readonly ApplicationDbContext _context;
        public CollectionItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CollectionItem> GetById(int id)
        {
            var item = await _context.CollectionItems.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
            return item;
        }
        public async Task<List<CollectionItem>> Get()
        {
            var items = await _context.CollectionItems.AsNoTracking().ToListAsync();
            return items;
        }

        public async Task<CollectionItem> Create(CollectionItemDto item)
        {
            var colectionItem = new CollectionItem
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Tags = item.Tags,
                CollectionId = item.CollectionId,
            };
            await _context.CollectionItems.AddAsync(colectionItem);
            await _context.SaveChangesAsync();

            return colectionItem;
        }

        public async Task<int> UpDate(int id, string name, string description, string[] tags)
        {
            var collectionItem = await _context.CollectionItems.Where(i => i.Id == id).ExecuteUpdateAsync(s => s
           .SetProperty(i => i.Name, i => name)
           .SetProperty(i => i.Description, i => description).SetProperty(i => i.Tags, i => tags));

            await _context.SaveChangesAsync();
            return collectionItem;
        }

        public async Task<int> Delete(int id)
        {
            await _context.CollectionItems.Where(i => i.Id == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();

            return id;
        }
    }
}
