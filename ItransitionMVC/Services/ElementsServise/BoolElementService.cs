using ItransitionMVC.Interfaces.IElementRepository;
using ItransitionMVC.Interfaces.IElementService;

namespace ItransitionMVC.Services.ElementsServise
{
    public class BoolElementService : IBoolElementService
    {
        readonly IBoolElementRepository _boolElementRepository;
        public BoolElementService(IBoolElementRepository boolElementRepository)
        {
            _boolElementRepository = boolElementRepository;
        }

        public void CreateBoolElem(string[] boolName, Guid id)
        {
            if(boolName != null)
            {
                foreach (var boolElem in boolName)
                {
                    _boolElementRepository.Create(boolElem, id);
                }
            }

        }
    }
}
