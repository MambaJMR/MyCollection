using ItransitionMVC.Code.DataBase;
using ItransitionMVC.Interfaces.IElementRepository;
using ItransitionMVC.Models;
using ItransitionMVC.Models.Elements;

namespace ItransitionMVC.Repositories.CustomElement
{
    public class StringElementRepository : IStringElementRepository
    {
        readonly ApplicationDbContext _context;
        public StringElementRepository(ApplicationDbContext applicationDb)
        {
            _context = applicationDb;
        }

        public void Create(string name, Guid id)
        {
            var elem = new ElementString
            {
                Name = name,
                CollectionId = id
            };
            _context.StringElements.Add(elem);
            _context.SaveChanges();
        }
    }
}
