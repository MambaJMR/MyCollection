using ItransitionMVC.Interfaces;
using ItransitionMVC.Models.Item;
using Newtonsoft.Json.Linq;

namespace ItransitionMVC.Services
{
    public class TagService
    {
        readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<List<Tag>> TagCreate(List<string> tag, Guid id)
        {
            List<Tag> tags = new List<Tag>();
            foreach (var tagItem in tag)
            {
                tags.Add(await _tagRepository.CreateTags(tagItem, id));
            }

            return tags;
        }

        public async Task<IEnumerable<Tag>> GetAllTags()
        {
            return await _tagRepository.GetAll();

        } 
    }
}
