using ItransitionMVC.Interfaces;
using ItransitionMVC.Models;
using ItransitionMVC.ModelViews;
using ItransitionMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItransitionMVC.Controllers
{
    public class CustomCollectionController : Controller
    {
        readonly ICustomCollectionService _customCollectionService;
        
        public CustomCollectionController(ICustomCollectionService customCollectionService)
        {
            _customCollectionService = customCollectionService;
        }

        [HttpGet]
        [Route("CustomCollection/Collections")]
        public async Task<IActionResult> Collections()
        {
            var collections = await _customCollectionService.GetCollections();
            return View(collections);
        }
        [HttpGet]
        [Route("CustomCollection/ItemsCollection/{id}")]
        public async Task<IActionResult> ItemsCollection(int id)
        {
            var collection = await _customCollectionService.GetCollectionById(id);
            return View(collection);
        }
        [HttpGet]
        public IActionResult CreateCollection()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCollection(CollectionDTO customCollection)
        {
            await _customCollectionService.CreateCustomCollection(customCollection);
            return View("Collections");
        }
        [HttpGet]
        public IActionResult UpdateCollection(int id)
        {
            //var collection = await _customCollectionService.GetCollectionById(id);
            //return View(collection);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCollection(CollectionDTO customCollection)
        {
            var collection = await _customCollectionService.UpdateCustomCollection(customCollection);
            return View(collection);
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            await _customCollectionService.DeleteCustomCollection(id);
            return RedirectToAction("Collections");
        }
    }
}
