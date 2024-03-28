using ItransitionMVC.Interfaces;
using ItransitionMVC.Interfaces.ICommentsAndLike;
using ItransitionMVC.Interfaces.IItem;
using ItransitionMVC.Models;
using ItransitionMVC.Models.Item;
using ItransitionMVC.ModelViews;
using ItransitionMVC.Repositories.LikeAndComments;
using Microsoft.AspNetCore.SignalR;
using NuGet.ContentModel;

namespace ItransitionMVC.Hubs
{
    public class ItemHub : Hub
    {
        private readonly ILikeRepository _likeRepository;
        private readonly ICollectionItemRepository _itemRepository;
        private readonly ICommentsService _commentsService;
        private readonly ICommentsRepository _commentsRepository;
        public ItemHub(ILikeRepository likeRepository, ICollectionItemRepository itemRepository, ICommentsService commentsService, ICommentsRepository commentsRepository)
        {
            _likeRepository = likeRepository;
            _itemRepository = itemRepository;
            _commentsService = commentsService;
            _commentsRepository = commentsRepository;

        }
        public async Task Like(string itemId, string userName)
        {
            var item = await _itemRepository.GetById(Guid.Parse(itemId));
            CheckLikes(userName, item);

            var likeCount = item.ItemLikes?.Count;
            var userLike = item.ItemLikes?.Where(x => x.UserId == userName).Count();

            await Clients.All.SendAsync("Likes", likeCount, userLike);
        }
        
        private void CheckLikes(string userName, CustomCollectionItem item)
        {
            if (!item.ItemLikes.Where(x => x.UserId == userName).Any())
            {
                item.ItemLikes.Add(new Like { UserId = userName, ItemId = item.Id });

                _likeRepository.CreateLike(new Like { UserId = userName, ItemId = item.Id });
            }
            else
            {
                _likeRepository.RemoveLike(item.ItemLikes.Where(x => x.UserId == userName).First());
            }
        }

        public async Task Comments(string itemId, string userName, string comment)
        {
            var item = await _itemRepository.GetById(Guid.Parse(itemId));
            if (comment != null)
            {
               item.ItemComments.Add(new Comment { CommentCreateDate = DateTime.Now, UserName = userName, CommentValue = comment, ItemId = Guid.Parse(itemId) });
            }
            await _commentsRepository.CreateComment(new Comment { CommentCreateDate = DateTime.Now.ToUniversalTime(), UserName = userName, CommentValue = comment, ItemId = Guid.Parse(itemId) });
            await _commentsService.AddComment(new Comment { CommentCreateDate = DateTime.Now.ToUniversalTime(), UserName = userName, CommentValue = comment, ItemId = Guid.Parse(itemId) });

            await Clients.All.SendAsync("Comments", DateTime.Now.ToShortDateString(), DateTime.Now.ToUniversalTime(), userName, comment);
        }
    }
}
