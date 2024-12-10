using ItransitionMVC.Models;

namespace ItransitionMVC.Interfaces.IElementRepository
{
    public interface IStringElementRepository
    {
        void Create(string name, Guid id);
    }
}