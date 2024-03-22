using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectItransition.Dto;
using ProjectItransition.Interfaces;
using ProjectItransition.Models.CollectionModels;

namespace ProjectItransition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ICollectionService _collectionService;
        private readonly IItemService _itemService;
        public HomeController(ICollectionService collectionService, IItemService itemService)
        {
            _collectionService = collectionService;
            _itemService = itemService;

        }

        [HttpGet]
        [Route("index")]
        public async Task<ActionResult<List<CollectionDto>>> GetAllCollection()
        {
            var collection = await _collectionService.GetAllCollects();
            return Ok(collection);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<CollectionItemDto>>> Get(int id)
        {
            List<object> collectionItems = new List<object>();
            var item = await _collectionService.GetCollectById(id);
            foreach(var itemDto in  item.Items) 
            {
                collectionItems.Add(itemDto);
            }

            return Ok(collectionItems);
            
        }
    }
}
