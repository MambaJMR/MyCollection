using ItransitionMVC.Models;

namespace ItransitionMVC.Interfaces
{
    public interface IElasticService
    {
        Task CreateElascticCollection(ElasticModel elasticModel);
        Task<List<ElasticModel>> ElasticSearch(string search);
    }
}