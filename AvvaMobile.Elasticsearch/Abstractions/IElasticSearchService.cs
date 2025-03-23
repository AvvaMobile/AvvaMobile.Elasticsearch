namespace AvvaMobile.Elasticsearch.Abstractions;

public interface IElasticSearchService
{
	Task<bool> IndexDocumentAsync<T>(T document, string indexName) where T : class;
	Task<T> GetDocumentAsync<T>(string id, string indexName = null) where T : class;
}