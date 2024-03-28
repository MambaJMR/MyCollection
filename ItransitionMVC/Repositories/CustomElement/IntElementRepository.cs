using ItransitionMVC.Code.DataBase;
using ItransitionMVC.Interfaces.IElementRepository;
using ItransitionMVC.Models;
using ItransitionMVC.Models.Elements;

namespace ItransitionMVC.Repositories.CustomElement
{
    public class IntElementRepository : IIntElementRepository
    {
        readonly ApplicationDbContext _context;
        public IntElementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(string name, Guid id)
        {
            var elem = new ElementInt
            {
                IntName = name,
                CollectionId = id
            };
            _context.IntElements.Add(elem);
            _context.SaveChanges();
        }
    }
}
