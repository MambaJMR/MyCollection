using ItransitionMVC.Code.DataBase;
using ItransitionMVC.Interfaces.ICollection;
using ItransitionMVC.Models.Collection;
using ItransitionMVC.Models.Item;
using ItransitionMVC.ModelViews;
using Microsoft.EntityFrameworkCore;


namespace ItransitionMVC.Repositories
{
    public class CustomCollectionRepository : ICustomCollectionRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomCollectionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CustomCollection> GetById(Guid id)
        {
            var item = await _context.Collections.AsNoTracking()
                .Include(c => c.Items)
                .Include(x => x.ItemElements)
                .Include(x => x.ItemIntElements)
                .Include(x => x.ItemBoolElements)
                .Include(x => x.ItemDateElements)
                .FirstOrDefaultAsync(i => i.Id == id);
            return item;
        }

        public async Task<List<CustomCollection>> GetUserCollections(string userId)
        {
            
            var collection = await _context.Collections.AsNoTracking()
                .Where(x => x.UserName == userId)
                .Include(x => x.Items)
                .Include(x => x.ItemElements)
                .Include(x => x.ItemIntElements)
                .Include(x => x.ItemBoolElements)
                .Include(x => x.ItemDateElements)
                .ToListAsync();
            return collection;
        }
        public async Task<List<CustomCollection>> Get()
        {
            var collections = await _context.Collections.AsNoTracking().Include(i => i.Items).ToListAsync();
            return collections;
        }

        public async Task<CustomCollection> Create(string userId,CollectionDTO collect, string image)
        {
            var collection = new CustomCollection
            {
                Name = collect.Name,
                Description = collect.Description,
                ImageUrl = image,
                typeCollection = collect.typeCollection,
                UserName = userId
            };
            
            await _context.Collections.AddAsync(collection);
            await _context.SaveChangesAsync();


            return collection;
        }

        public async Task<int> UpDate(CollectionDTO collect)
        {
            var collection = await _context.Collections.Where(i => i.Id == collect.Id).ExecuteUpdateAsync(s => s
           .SetProperty(i => i.Name, i => collect.Name)
           .SetProperty(i => i.typeCollection, i => collect.typeCollection)
           .SetProperty(i => i.Description, i => collect.Description)
           );

            await _context.SaveChangesAsync();
            return collection;
        }
        
        public async Task<Guid> Delete(Guid id)
        {
            await _context.Collections.Where(i => i.Id == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();

            return id;
        }


    }
}
