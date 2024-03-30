using ItransitionMVC.Interfaces;
using ItransitionMVC.Interfaces.ICollection;
using ItransitionMVC.Interfaces.IItem;
using ItransitionMVC.ModelViews;

namespace ItransitionMVC.Services
{
    public class OrderByService : IOrderByService
    {
        readonly ICustomCollectionService _customCollectionService;
        readonly ICollectionItemService _itemService;
        readonly TagService _tagService;

        public OrderByService(ICustomCollectionService customCollectionService, ICollectionItemService collectionItemService, TagService tagService)
        {
            _customCollectionService = customCollectionService;
            _itemService = collectionItemService;
            _tagService = tagService;
        }


        public async Task<IndexViewModel> OrderByHomeIndex()
        {
            const int itemsCount = 10;
            const int collectionsCount = 5;

            var items = await _itemService.GetAllItems();
            items = items.OrderByDescending(x => x.Id).Take(itemsCount);

            var collections = await _customCollectionService.GetCollections();
            collections = collections.OrderByDescending(x => x.Items.Count).Take(collectionsCount);

            var tags = await _tagService.GetAllTags();

            return new IndexViewModel { CollectionItems = items, Tags = tags, Collections = collections };
        }
    }
}
