using ItransitionMVC.Interfaces;
using ItransitionMVC.Interfaces.ICollection;
using ItransitionMVC.Models.Item;
using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;

namespace ItransitionMVC.Controllers
{
    public class SearchController : Controller
    {
        private readonly IElasticService _elasticService;
        public SearchController(IElasticService elasticService)
        {
            _elasticService = elasticService;
        }
        public async Task<IActionResult> Search(string searchText)
        {
           // await _elasticService.CreateElascticCollection();
            var result = await _elasticService.ElasticSearch(searchText);
            if(result == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(result);
        }

        //private IEnumerable<CustomCollectionItem> SearchItems(string search)
        //{
        //    List<CustomCollectionItem> items = new List<CustomCollectionItem>();
        //    items.AddRange(_repository.FreeTextOnDescription(search));
        //    //items.AddRange(_collectionRepo.FreeTextOnNameCollection(search));
        //    //items.AddRange(_itemRepo.FreeTextOnNameItem(search));
        //    //items.AddRange(_itemRepo.FreeTextOnComment(search));
        //    //items.AddRange(_itemRepo.FreeTextOnMarkdown(search));
        //    //items.AddRange(_itemRepo.FreeTextOnString(search));
        //    //items.AddRange(_tagRepo.FreeTextOnNameTags(search));
        //    return items.Distinct();
        //}
    }
}
