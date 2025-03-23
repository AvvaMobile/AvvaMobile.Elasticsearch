﻿using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mlink.AdDistribution.Shared.Elastic.Abstractions;
using Mlink.AdDistribution.Shared.Elastic.Implementations;

namespace Mlink.AdDistribution.Shared.Elastic.DependencyInjection;

public static class Registration
{
	public static IServiceCollection AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
	{
		var url = configuration["ElasticSearchOptions:Uri"];
		var elasticUserName = configuration["ElasticSearchOptions:ElasticUserName"];
		var elasticPassword = configuration["ElasticSearchOptions:ElasticPassword"];

		var settings = new ElasticsearchClientSettings(new Uri(url))
			.Authentication(new BasicAuthentication(elasticUserName, elasticPassword))
			.RequestTimeout(TimeSpan.FromMinutes(2));

		var client = new ElasticsearchClient(settings);

		services.AddSingleton(client);

		services.AddTransient<IElasticSearchService, ElasticSearchService>();

		return services;
	}
}