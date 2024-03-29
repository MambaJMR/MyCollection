using ItransitionMVC.Interfaces;
using ItransitionMVC.Interfaces.ICollection;
using ItransitionMVC.Interfaces.IItem;
using ItransitionMVC.Models.Item;
using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;

namespace ItransitionMVC.Controllers
{
    public class SearchController : Controller
    {
        private readonly IElasticService _elasticService;
        private readonly ICollectionItemService _itemService;
        public SearchController(IElasticService elasticService, ICollectionItemService itemService)
        {
            _elasticService = elasticService;
            _itemService = itemService;
        }
        public async Task<IActionResult> Search(string searchText)
        {
            List<CustomCollectionItem> items = new List<CustomCollectionItem>();
            var result = await _elasticService.ElasticSearch(searchText);

            if (result == null)
            {
                return RedirectToAction("Index", "Home");
            }

            foreach (var i in result)
            {
                var item = await _itemService.GetItemById(i.ItemId);
                items.Add(item);
            }

            return View(items);
        }

    }
}
