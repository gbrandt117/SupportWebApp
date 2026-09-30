using Microsoft.Azure.Cosmos;
using SupportWebApp.Models;

namespace SupportWebApp.Services;

public class CosmosDbService
{
    private readonly Container _container;

    public CosmosDbService(IConfiguration configuration)
    {
        var connectionString = configuration["CosmosDb:ConnectionString"];
        var databaseName = configuration["CosmosDb:DatabaseName"];
        var containerName = configuration["CosmosDb:ContainerName"];

        var client = new CosmosClient(connectionString);

        _container = client.GetContainer(databaseName, containerName);
    }

    public async Task AddSupportMessageAsync(SupportMessage message)
    {
        var item = new
        {
            id = message.Id,
            name = message.Name,
            email = message.Email,
            phone = message.Phone,
            description = message.Description,
            category = message.Category,
            createdAt = message.CreatedAt
        };

        await _container.CreateItemAsync(
            item,
            new PartitionKey(message.Category));
    }

    public async Task<List<SupportMessage>> GetSupportMessagesAsync()
    {
        var query = _container.GetItemQueryIterator<SupportMessage>(
            new QueryDefinition("SELECT * FROM c"));

        var results = new List<SupportMessage>();

        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            results.AddRange(response);
        }

        return results;
    }
}