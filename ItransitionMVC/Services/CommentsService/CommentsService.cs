using ItransitionMVC.Interfaces;
using ItransitionMVC.Interfaces.ICommentsAndLike;
using ItransitionMVC.Models;
using ItransitionMVC.Models.Item;

namespace ItransitionMVC.Services.CommentsService
{
    public class CommentsService : ICommentsService
    {
        readonly IElasticService _elasticService;
        public CommentsService(IElasticService elasticService)
        {
            _elasticService = elasticService;
        }

        public async Task AddComment(Comment comment)
        {
            var item = new ElasticModel
            {
                ItemId = comment.ItemId,
                Comments = comment.CommentValue
            };
            await _elasticService.CreateElascticCollection(item);
        }
    }
}
