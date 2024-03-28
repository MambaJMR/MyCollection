using ItransitionMVC.Interfaces.ICollection;
using ItransitionMVC.Interfaces.IItem;
using ItransitionMVC.ModelViews;
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
        public async Task<IActionResult> CustomCollectionItems(Guid id)
        {
            var collectionItems = await _customCollectionService.GetCollectionById(id);
            
            return View(collectionItems);
        }

        [HttpGet]
        public async Task<IActionResult> ItemView(Guid id)
        {
            var item = await _collectionItemService.GetItemById(id);
            //var itemDto = new ItemDto
            //{
            //    Name = item.Name,
            //    Collection = item.Collection,
            //    BoolValue = item.BoolValue,
            //    IntValue = item.IntValueInItem,
            //    DateValue = item.DateValue,
            //    StrValue = item.StringValue,
            //    Description = item.Description,
            //    Likes = item.ItemLikes,
            //    Comments = item.ItemComments
            //};
            return View(item);
        }

    }
}
