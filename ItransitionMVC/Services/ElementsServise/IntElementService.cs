using ItransitionMVC.Interfaces.IElementRepository;
using ItransitionMVC.Interfaces.IElementService;

namespace ItransitionMVC.Services.ElementsServise
{
    public class IntElementService : IIntElementService
    {
        readonly IIntElementRepository _intElementRepository;
        public IntElementService(IIntElementRepository intElementRepository)
        {
            _intElementRepository = intElementRepository;
        }

        public void CreateIntElem(string[] intName, Guid id)
        {
            if (intName != null)
            {
                foreach (var intElem in intName)
                {
                    _intElementRepository.Create(intElem, id);
                }
            }
        }
    }
}
