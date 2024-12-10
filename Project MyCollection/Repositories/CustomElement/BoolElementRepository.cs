
using ItransitionMVC.Code.DataBase;
using ItransitionMVC.Interfaces.IElementRepository;
using ItransitionMVC.Models.Elements;

namespace ItransitionMVC.Repositories.CustomElement
{
    public class BoolElementRepository : IBoolElementRepository 
    { 
        readonly ApplicationDbContext _context;
        public BoolElementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(string name, Guid id)
        {
            var elem = new ElementBool
            {
                BoolName = name,
                CollectionId = id
            };
            _context.BoolElements.Add(elem);
            _context.SaveChanges();
        }

        
    }
}
