using Application.Services.Repositories;
using Domain.Models;
using RestSharp;

namespace Persistence.Repositories;

public class ObjectRepository : IObjectRepository<Domain.Models.Object>
{
    private readonly RestClient _client;
    public ObjectRepository()
    {
        _client = new RestClient("https://restful-api.dev/");
    }
    public async Task<string> CreateMockAPIModel(Domain.Models.Object mockAPIModel)
    {
        var request = new RestRequest("objects", Method.Post);
        request.AddJsonBody(mockAPIModel);

        var response = await _client.ExecuteAsync(request);

        if (!response.IsSuccessful)
        {
            throw new Exception($"API Error: {response.StatusCode}");
        }

        return response.Content;
    } 
}