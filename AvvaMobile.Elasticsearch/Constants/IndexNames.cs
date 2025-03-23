namespace Mlink.AdDistribution.Shared.Elastic.Constants;

public static class IndexNames
{   
    private static string GetIndexName(string indexName)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        
        return environment switch
        {
            "Development" => $"{indexName}",
            "Staging" => $"{indexName}",
            "Production" => indexName,
            _ => $"{indexName}"
        };
    }
}