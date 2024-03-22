using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectItransition.Dto;
using ProjectItransition.Interfaces;
using ProjectItransition.Models.CollectionModels;
using ProjectItransition.Services;

namespace ProjectItransition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //Только Авторизованные пользователи
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionService _collectionService;
        public CollectionController(ICollectionService collectionService)
        {
            _collectionService = collectionService;
        }
        [HttpGet]
        public async Task<ActionResult<List<CollectionDto>>> Get()
        {
            var collection = await _collectionService.GetAllCollects();
            return Ok(collection);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CollectionDto collect, IFormFile file)
        {
            var collection = await _collectionService.CreateCollect(collect);
            return Ok(collection);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CollectionDto collect)
        {
            var collection = await _collectionService.UpDateCollect(collect.Id, collect.Name, collect.Description, collect.ImageUrl);
            //добавить проверку на валидность
            return Ok(collection);  
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {  
            await _collectionService.DeleteCollect(id);
            //добавить проверку на валидность
            return Ok();
        }
    }
}
