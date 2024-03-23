using ItransitionMVC.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ItransitionMVC.Controllers
{

    public class HomeController : Controller
    {
        readonly ICustomCollectionService _customCollectionService;
        readonly ICollectionItemService _collectionItemService;

        public HomeController(ICustomCollectionService customCollectionService, ICollectionItemService collectionItemService)
        {
            _customCollectionService = customCollectionService;
            _collectionItemService = collectionItemService;
        }

        public async Task<IActionResult> Index()
        {
            var collections = await _customCollectionService.GetCollections();
            return View(collections);
        }
        [HttpGet]
        [Route("Home/customCollection/{id}")]
        public async Task<IActionResult> CustomCollectionItems(Guid id)
        {
            var collectionItems = await _customCollectionService.GetCollectionById(id);
            return View(collectionItems);
        }

        [HttpGet]
        [Route("Home/ItemView/{id}")]
        public async Task<IActionResult> ItemView(Guid id)
        {
            var item = await _collectionItemService.GetItemById(id);
            return View(item);
        }
    }
}
