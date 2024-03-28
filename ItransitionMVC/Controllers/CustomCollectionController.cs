using ItransitionMVC.Interfaces.ICollection;
using ItransitionMVC.Interfaces.IElementService;
using ItransitionMVC.Interfaces.IItem;
using ItransitionMVC.Models;
using ItransitionMVC.ModelViews;
using ItransitionMVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;

namespace ItransitionMVC.Controllers
{
    [Authorize]
    public class CustomCollectionController : Controller
    {
        readonly ICustomCollectionService _customCollectionService;
        readonly IStringElementService _stringElementService;
        readonly IIntElementService _intElementService;
        readonly IBoolElementService _boolElementService;
        readonly IDateElementService _dateElementService;
        
        public CustomCollectionController(
            ICustomCollectionService customCollectionService, 
            IStringElementService stringElementService,
            IIntElementService intElementService,
            IBoolElementService boolElementService,
            IDateElementService dateElementService
            )
        {
            _customCollectionService = customCollectionService;
            _stringElementService = stringElementService;  
            _intElementService = intElementService;
            _boolElementService = boolElementService;
            _dateElementService = dateElementService;
        }

        [HttpGet]
        public async Task<IActionResult> Collections(string userId)
        {
            var collections = await _customCollectionService.GetUserCollections(userId);
            return View(collections);
        }
        [HttpGet]

        public async Task<IActionResult> ItemsCollection(Guid id)
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
        public async Task<IActionResult> CreateCollection(string userId, CollectionDTO customCollection)
        {
            var collection = await _customCollectionService.CreateCustomCollection(userId, customCollection);
            _stringElementService.CreateStrElem(customCollection.ElementName, collection.Id);
            _intElementService.CreateIntElem(customCollection.IntName, collection.Id);
            _boolElementService.CreateBoolElem(customCollection.BoolName, collection.Id);
            _dateElementService.CreateDateElem(customCollection.DateName, collection.Id);

            return RedirectToAction("Collections", "CustomCollection", new { userId });
        }
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            return Ok();
        }
        [HttpGet]
        public IActionResult UpdateCollection()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCollection(CollectionDTO customCollection)
        {
            var collection = await _customCollectionService.UpdateCustomCollection(customCollection);
            return View(collection);
        }
        
        public async Task<IActionResult> Delete(Guid id)
        {
            await _customCollectionService.DeleteCustomCollection(id);
            return RedirectToAction("Index", "Home");
        }
    }
}
