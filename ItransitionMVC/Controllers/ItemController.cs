using ItransitionMVC.Interfaces;
using ItransitionMVC.Interfaces.ICollection;
using ItransitionMVC.Interfaces.IItem;
using ItransitionMVC.Models;
using ItransitionMVC.Models.Item;
using ItransitionMVC.ModelViews;
using ItransitionMVC.Repositories;
using ItransitionMVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItransitionMVC.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        private readonly ICollectionItemService _itemService;
        private readonly ICustomCollectionService _customCollectionService;
        private readonly TagService _tagService;
        private readonly IElasticService _elasticService;
        public ItemController(ICollectionItemService itemService,
            ICustomCollectionService customCollectionService,
            TagService tagService,
            IElasticService elasticService)
        {
            _itemService = itemService;
            _customCollectionService = customCollectionService;
            _tagService = tagService;
            _elasticService = elasticService;

        }
        public async Task<IActionResult> Get() 
        {
            var items = await _itemService.GetAllItems();
            return View(items);
        }

        [HttpGet]
        
        public async Task<IActionResult> ItemCollections(Guid id)
        {
            var item = await _itemService.GetItemById(id);

            return View(item);
        }

        [HttpGet]
        public async Task<IActionResult> CreateItem(Guid id) 
        {
            var collection = await _customCollectionService.GetCollectionById(id);
            var itemView = new ItemView
            {
                CollectionId = collection.Id,
                Collection = collection,
                ElementString = collection.ItemElements,
                ElementBool = collection.ItemBoolElements,
                ElementDate = collection.ItemDateElements,
                ElementInt = collection.ItemIntElements
            };
            return View(itemView);

        }
        [HttpPost]
        public async Task<IActionResult> CreateItem(ItemDto collectionItem)
        {
            var item = await _itemService.CreateItem(collectionItem);
            await _tagService.TagCreate(collectionItem.Tags, item.Id);
            var getItem = await _itemService.GetItemById(item.Id);
            
            
            await _elasticService.CreateElascticCollection(CreateModel(getItem));
            return RedirectToAction("ItemsCollection", "CustomCollection",new {id = collectionItem.CollectionId});
        }
        [HttpGet]
        public  IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(CustomCollectionItem collectionItem)
        {
            await _itemService.UpDateItem(collectionItem);
            return View();
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _itemService.DeleteItem(id);
            return RedirectToAction("Index", "Home");
        }

        private ElasticModel CreateModel(CustomCollectionItem customCollectionItem)
        {
            string tags = string.Empty;
            foreach (var tag in customCollectionItem.ItemTags)
            {
                tags += $"{tag.Name} ";
            }
            var model = new ElasticModel
            {
                ItemId = customCollectionItem.Id,
                DescriptionItem = customCollectionItem.Description,
                NameItem = customCollectionItem.Name,
                StrValue = customCollectionItem.StrValue,
                NameCollection = customCollectionItem.Collection.Name,
                CollectionId = customCollectionItem.CollectionId,
                DescriptionCollection = customCollectionItem.Collection.Description,
                Tags = tags
            };
            return model;
        }
    }
}
