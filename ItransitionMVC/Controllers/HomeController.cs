using ItransitionMVC.Interfaces.ICollection;
using ItransitionMVC.Interfaces.IItem;
using ItransitionMVC.Services;
using Microsoft.AspNetCore.Mvc;


namespace ItransitionMVC.Controllers
{

    public class HomeController : Controller
    {
        readonly ICustomCollectionService _customCollectionService;
        readonly ICollectionItemService _collectionItemService;
        readonly TagService _tagService;


        public HomeController(ICustomCollectionService customCollectionService, ICollectionItemService collectionItemService, TagService tagService)
        {
            _customCollectionService = customCollectionService;
            _collectionItemService = collectionItemService;
            _tagService = tagService;
            
        }

        public async Task<IActionResult> Index()
        {
            var collections = await _customCollectionService.GetCollections();
            
            return View(collections);
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

    }
}
