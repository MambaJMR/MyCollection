using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectItransition.Dto;
using ProjectItransition.Interfaces;

namespace ProjectItransition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CollectionItemDto>>> Get()
        {
            var items = await _itemService.GetAllItems();
            return Ok(items);
        }

        //public async Task<ActionResult<CollectionItemDto>> GetById()
        //{
        //    var item = await _itemService.GetItemById();
        //}
        [HttpPost]
        public async Task<ActionResult<CollectionItemDto>> Create(CollectionItemDto itemDto)
        {
            var item = await _itemService.CreateItem(itemDto);
            return Ok(item);
        }
        [HttpPut]
        public async Task<ActionResult> Update(CollectionItemDto itemDto)
        {
            var item = await _itemService.UpDateItem(itemDto);
            return Ok(item);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _itemService.DeleteItem(id);
            return Ok();
        }
    }
}
