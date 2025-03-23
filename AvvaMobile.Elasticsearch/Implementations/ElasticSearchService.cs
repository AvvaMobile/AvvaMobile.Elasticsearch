using Elastic.Clients.Elasticsearch;
using AvvaMobile.Elasticsearch.Abstractions;

namespace AvvaMobile.Elasticsearch.Implementations;

public class ElasticSearchService : IElasticSearchService
{
	private readonly ElasticsearchClient _elasticClient;

	public ElasticSearchService(ElasticsearchClient elasticClient)
	{
		_elasticClient = elasticClient;
	}

	public async Task<bool> IndexDocumentAsync<T>(T document, string indexName) where T : class
	{
		var response = await _elasticClient.IndexAsync(document, idx => idx.Index(indexName));
		return response.IsValidResponse;
	}

	public async Task<T> GetDocumentAsync<T>(string id, string indexName) where T : class
	{
		var response = await _elasticClient.GetAsync<T>(id, g => g.Index(indexName));
		return response.Source;
	}
}