using ItransitionMVC.Interfaces;
using ItransitionMVC.Models;
using ItransitionMVC.ModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItransitionMVC.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        private readonly ICollectionItemService _itemService;
        private readonly ICustomCollectionService _customCollectionService;
        public ItemController(ICollectionItemService itemService, ICustomCollectionService customCollectionService)
        {
            _itemService = itemService;
            _customCollectionService = customCollectionService;

        }
        public async Task<IActionResult> Get() 
        {
            var items = await _itemService.GetAllItems();
            return View(items);
        }

        [HttpGet]
        [Route("/ItemCollections/{id}")]
        public async Task<IActionResult> ItemCollections(Guid id)
        {
            var item = await _itemService.GetItemById(id);
            return View(item);
        }

        [HttpGet]
        public async Task<IActionResult> CreateItem(Guid id) 
        {
            var collection = await _customCollectionService.GetCollectionById(id);
            return View(collection);
        }
        [HttpPost]
        public async Task<IActionResult> CreateItem(ItemDto collectionItem)
        {
            await _itemService.CreateItem(collectionItem);
            return RedirectToAction("ItemsCollection", "CustomCollection",new {id = collectionItem.CollectionId});
        }

        public async Task<IActionResult> Update(CustomCollectionItem collectionItem)
        {
            var item = await _itemService.UpDateItem(collectionItem);
            return View(item);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _itemService.DeleteItem(id);
            return RedirectToAction("AllItems");
        }
    }
}
