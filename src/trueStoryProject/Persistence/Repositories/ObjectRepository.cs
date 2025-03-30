using Application.Services.Repositories;
using System.Text;
namespace Persistence.Repositories;

/// <summary>
/// This repository behaves as if it is connected to the Database.
/// </summary>
public class ObjectRepository : IObjectRepository
{
    private readonly HttpClient _client;

    public ObjectRepository()
    {
        _client = new HttpClient();
    }
     
    public async Task<string> CreateObjectModel(Domain.Models.Object mockAPIModel)
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(mockAPIModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("https://api.restful-api.dev/objects", content);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"API Error: {response.StatusCode}");
        

        return await response.Content.ReadAsStringAsync();
    }
}