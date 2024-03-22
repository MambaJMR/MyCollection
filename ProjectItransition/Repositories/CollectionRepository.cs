using Microsoft.EntityFrameworkCore;
using ProjectItransition.Data;
using ProjectItransition.Dto;
using ProjectItransition.Interfaces;
using ProjectItransition.Models.CollectionModels;

namespace ProjectItransition.Repositories
{
    public class CollectionRepository : ICollectionRepository
    {
        private readonly ApplicationDbContext _context;
        public CollectionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Collect> GetById(int id)
        {
            var item = await _context.Collections.AsNoTracking().Include(c => c.Items).FirstOrDefaultAsync(i => i.Id == id);
            return item;
        }

        public async Task<List<Collect>> Get()
        {
            var collections = await _context.Collections.AsNoTracking().Include(c => c.Items).ToListAsync();
            return collections;
        }

        public async Task<Collect> Create(CollectionDto collect)
        {
            var collection = new Collect
            {
                Name = collect.Name,
                Description = collect.Description,
                ImageUrl = collect.ImageUrl,
                typeCollection = collect.typeCollection,
            };
            await _context.Collections.AddAsync(collection);
            await _context.SaveChangesAsync();

            return collection;
        }

        public async Task<int> UpDate(int id, string name, string description, string url)
        {
            var collection = await _context.Collections.Where(i => i.Id == id).ExecuteUpdateAsync(s => s
           .SetProperty(i => i.Name, i => name)
           .SetProperty(i => i.Description, i => description)
           .SetProperty(i => i.ImageUrl, i => url));

            await _context.SaveChangesAsync();
            return collection;
        }

        public async Task<int> Delete(int id)
        {
            await _context.Collections.Where(i => i.Id == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();

            return id;
        }


    }
}
