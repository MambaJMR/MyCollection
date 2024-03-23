using ItransitionMVC.Code.DataBase;
using ItransitionMVC.Interfaces;
using ItransitionMVC.Models;
using ItransitionMVC.ModelViews;
using Microsoft.EntityFrameworkCore;


namespace ProjectItransition.Repositories
{
    public class CollectionItemRepository : ICollectionItemRepository
    {
        private readonly ApplicationDbContext _context;
        public CollectionItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CustomCollectionItem> GetById(Guid id)
        {
            var item = await _context.CollectionItems.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
            return item;
        }
        public async Task<List<CustomCollectionItem>> Get()
        {
            var items = await _context.CollectionItems.AsNoTracking().ToListAsync();
            return items;
        }

        public async Task<CustomCollectionItem> Create(ItemDto item)
        {
            var colectionItem = new CustomCollectionItem
            {
                Name = item.Name,
                Description = item.Description,
                //Tags = item.Tags,
                CollectionId = item.CollectionId,
            };
            await _context.CollectionItems.AddAsync(colectionItem);
            await _context.SaveChangesAsync();

            return colectionItem;
        }

        public async Task<int> UpDate(CustomCollectionItem item)
        {
            var collectionItem = await _context.CollectionItems.Where(i => i.Id == item.Id).ExecuteUpdateAsync(s => s
           .SetProperty(i => i.Name, i => item.Name)
           .SetProperty(i => i.Description, i => item.Description)
           .SetProperty(i => i.Tags, i => item.Tags));

            await _context.SaveChangesAsync();
            return collectionItem;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.CollectionItems.Where(i => i.Id == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();

            return id;
        }
    }
}
