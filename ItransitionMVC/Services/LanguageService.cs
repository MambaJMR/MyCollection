using Microsoft.Extensions.Localization;
using System.Reflection;

namespace ItransitionMVC.Services
{
    public class SharedResurse
    {

    }
    public class LanguageService
    {
        readonly IStringLocalizer _stringLocalizer;


        public LanguageService(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResurse);
            var assamblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _stringLocalizer = factory.Create("SharedResurse", assamblyName.Name);
        }

        public LocalizedString GetKey(string key)
        {
            return _stringLocalizer[key];
        }
    }
}
