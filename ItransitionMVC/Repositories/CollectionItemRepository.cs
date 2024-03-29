using ItransitionMVC.Code.DataBase;
using ItransitionMVC.Interfaces.IItem;
using ItransitionMVC.Models.Item;
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
            var item = await _context.CollectionItems.AsNoTracking()
                .Include(c => c.ItemLikes)
                .Include(c => c.ItemComments)
                .Include(c => c.ItemTags)
                .Include(c => c.Collection)
                .Include(c => c.Collection.ItemElements)
                .Include(c => c.Collection.ItemBoolElements)
                .Include(c => c.Collection.ItemIntElements)
                .Include(c => c.Collection.ItemDateElements)
                .FirstOrDefaultAsync(i => i.Id == id);
            return item;
        }
        public async Task<List<CustomCollectionItem>> Get()
        {
            var items = await _context.CollectionItems.AsNoTracking()
                .Include(c => c.ItemLikes)
                .Include(c => c.ItemComments)
                .Include(c => c.ItemTags)
                .Include(c => c.Collection)
                .Include(c => c.Collection.ItemElements)
                .Include(c => c.Collection.ItemBoolElements)
                .Include(c => c.Collection.ItemIntElements)
                .Include(c => c.Collection.ItemDateElements)
                .ToListAsync();
            return items;
        }

        
        public async Task<CustomCollectionItem> Create(ItemDto item)
        {
            List<DateTime> dateToUtc = new List<DateTime>();

            foreach (var date in item.DateValue)
            {
                dateToUtc.Add (date.ToUniversalTime());
            }
            var colectionItem = new CustomCollectionItem
            {
                Name = item.Name,
                Description = item.Description,
                ItemLikes = item.Likes,
                CollectionId = item.CollectionId,
                StrValue = item.StrValue,
                IntValue = item.IntValue,
                BoolValue = item.BoolValue,
                DateValue = dateToUtc
            };
            await _context.CollectionItems.AddAsync(colectionItem);
            await _context.SaveChangesAsync();

            return colectionItem;
        }

        public async Task UpDate(CustomCollectionItem item)
        {
            var collectionItem = await _context.CollectionItems.Where(i => i.Id == item.Id)
                .ExecuteUpdateAsync(s => s
           .SetProperty(i => i.Name, i => item.Name)
           .SetProperty(i => i.Description, i => item.Description));
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            await _context.CollectionItems.Where(i => i.Id == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();

        }
    }
}
