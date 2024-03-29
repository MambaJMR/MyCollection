using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Elastic.Transport;
using ItransitionMVC.Interfaces;
using ItransitionMVC.Interfaces.ICollection;
using ItransitionMVC.Interfaces.IItem;
using ItransitionMVC.Models;
using ItransitionMVC.Settings;
using Microsoft.Extensions.Options;

namespace ItransitionMVC.Services
{

    public class ElasticService : IElasticService
    {
        private ElasticsearchClient _elastic;
        public ElasticService(IOptions<ElasticSettings> elasticSettings)
        {
            string id = elasticSettings.Value.CloudId;
            string key = elasticSettings.Value.Key;
            _elastic = new ElasticsearchClient(id, new ApiKey(key));
        }
        public async Task CreateElascticCollection(ElasticModel elasticModel)
        {
            var response = await _elastic.IndexAsync(elasticModel, "my-collection-index");
            
            if (response.IsValidResponse)
            {
                var result = response.Result;
            }
        }

        public async Task<List<ElasticModel>> ElasticSearch(string search)
        {
            var response = await _elastic.SearchAsync<ElasticModel>(
                s => s.Index("my-collection-index")
                .From(0)
                .Size(10)
                .Query(x => x.MultiMatch(x => x.Query(search))));
                var item = response.Documents.ToList();
                return item;
        }
    }
}
