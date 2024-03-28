using ItransitionMVC.Code.DataBase;
using ItransitionMVC.Interfaces.IElementRepository;
using ItransitionMVC.Models;
using ItransitionMVC.Models.Elements;

namespace ItransitionMVC.Repositories.CustomElement
{
    public class DateElementRepository : IDateElementRepository
    {
        readonly ApplicationDbContext _context;
        public DateElementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(string name, Guid id)
        {
            var elem = new ElementDate
            {
                DateName = name,
                CollectionId = id
            };
            _context.DateElements.Add(elem);
            _context.SaveChanges();
        }
    }
}
