using Application.Services.Repositories;
using Domain;
using Microsoft.Extensions.Options;
using System.Text;
namespace Persistence.Repositories;

/// <summary>
/// This repository behaves as if it is connected to the Database.
/// </summary>
public class ObjectRepository : IObjectRepository
{
    private readonly HttpClient _client;
    private readonly UrlSetting _urlSetting;
    public ObjectRepository(HttpClient client, IOptions<UrlSetting> urlSetting)
    {
        _client = client;
        _urlSetting = urlSetting.Value ?? throw new ArgumentNullException(nameof(urlSetting), "UrlSetting cannot be null.");
    }



    public async Task<string> CreateObjectModel(Domain.Models.Object mockAPIModel)
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(mockAPIModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var requestUri = $"{_urlSetting.BaseUrl}objects";

        var response = await _client.PostAsync(requestUri, content);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"API Error: {response.StatusCode}");
        

        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> DeleteObjectModel(string objectId)
    {
        var requestUri = $"{_urlSetting.BaseUrl}objects/{objectId}";

        var response = await _client.DeleteAsync(requestUri);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"API Error: {response.StatusCode}");
        }

        return await response.Content.ReadAsStringAsync();
    }
}