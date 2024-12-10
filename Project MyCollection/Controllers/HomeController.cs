using ItransitionMVC.Interfaces.ICollection;
using ItransitionMVC.Interfaces.IItem;
using Microsoft.AspNetCore.Mvc;
using ItransitionMVC.Interfaces;
using Microsoft.AspNetCore.Localization;


namespace ItransitionMVC.Controllers
{

    public class HomeController : Controller
    {
        readonly ICustomCollectionService _customCollectionService;
        readonly ICollectionItemService _collectionItemService;
        readonly IOrderByService _orderByService;

        public HomeController(ICustomCollectionService customCollectionService, ICollectionItemService collectionItemService, IOrderByService orderByService)
        {
            _customCollectionService = customCollectionService;
            _collectionItemService = collectionItemService;
            _orderByService = orderByService;
            
        }
        public async Task<IActionResult> Index()
        {
            var indexModel = await _orderByService.OrderByHomeIndex();
            return View(indexModel);
        }

        [HttpGet]
        public async Task<IActionResult> CustomCollectionItems(Guid id)
        {
            var collectionItems = await _customCollectionService.GetCollectionById(id);
            
            return View(collectionItems);
        }

        [HttpGet]
        public async Task<IActionResult> ItemView(Guid id)
        {
            var item = await _collectionItemService.GetItemById(id);
           
            return View(item);
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)));
            new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) };

            return Redirect(Request.Headers["Referer"].ToString());
        }

    }
}
