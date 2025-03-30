using Domain.Models;
using RestSharp; 

namespace Application.Services.MockAPIModelService;

public class ObjectManager : IObjectService
{
    private readonly RestClient _client;
    public ObjectManager()
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
