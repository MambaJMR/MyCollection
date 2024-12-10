using ItransitionMVC.Interfaces.IElementRepository;
using ItransitionMVC.Interfaces.IElementService;
using ItransitionMVC.ModelViews;
using System.IO;

namespace ItransitionMVC.Services.ElementsServise
{
    public class StringElementService : IStringElementService
    {
        readonly IStringElementRepository _stringElementRepository;
        public StringElementService(IStringElementRepository stringElementRepository)
        {
            _stringElementRepository = stringElementRepository;
        }

        public void CreateStrElem(string[] strName, Guid id)
        {
            if (strName != null)
            {
                foreach (var strElem in strName)
                {
                    _stringElementRepository.Create(strElem, id);
                }
            }
        }
    }
}
