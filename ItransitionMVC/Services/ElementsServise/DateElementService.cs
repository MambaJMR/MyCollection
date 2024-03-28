using ItransitionMVC.Interfaces.IElementRepository;
using ItransitionMVC.Interfaces.IElementService;

namespace ItransitionMVC.Services.ElementsServise
{
    public class DateElementService : IDateElementService
    {
        readonly IDateElementRepository _dateElementRepository;
        public DateElementService(IDateElementRepository dateElementRepository)
        {
            _dateElementRepository = dateElementRepository;
        }

        public void CreateDateElem(string[] dateName, Guid id)
        {
            if (dateName != null) 
            {
                foreach (var dateElem in dateName)
                {
                    _dateElementRepository.Create(dateElem, id);
                }
            }

        }
    }
}
