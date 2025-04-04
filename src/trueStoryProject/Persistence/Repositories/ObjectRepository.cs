﻿using Application.Features.ObjectModels.Constants;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;
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
        _urlSetting = urlSetting.Value ?? throw new ArgumentNullException(nameof(urlSetting), ObjectModelMessages.UrlSettingCantBeNulL);
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
            throw new Exception($"API Error: {response.StatusCode}");
        

        return await response.Content.ReadAsStringAsync();
    }

    //Merge this repo and GetAllObject repo
    public async Task<IPaginate<Domain.Models.Object>> GetObjectByNameAsync(
    string? nameFilter = null,
    int index = 0,
    int size = 10,
    CancellationToken cancellationToken = default)
    {
        var requestUri = $"{_urlSetting.BaseUrl}objects?page={index}&pageSize={size}";

        if (!string.IsNullOrEmpty(nameFilter))
        {
           requestUri += $"&name={Uri.EscapeDataString(nameFilter)}";
        }

        var response = await _client.GetAsync(requestUri, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"API Error: {response.StatusCode}");
        }

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Domain.Models.Object>>(jsonResponse);

        if (result == null || !result.Any())
        {
            return Paginate.Empty<Domain.Models.Object>();
        }

        result = filterByName(result, nameFilter);

        var totalCount = result.Count;
        var paginatedItems = result.Skip(index * size).Take(size).ToList();
        var totalPages = (int)Math.Ceiling((double)totalCount / size);

        return new Paginate<Domain.Models.Object>(paginatedItems, index, size, 0)
        {
            Count = totalCount,
            Pages = totalPages
        };
    } 
 


    public async Task<List<Domain.Models.Object>> GetAllObjectsAsync(CancellationToken cancellationToken = default)
    {
        var requestUri = $"{_urlSetting.BaseUrl}objects";

        var response = await _client.GetAsync(requestUri, cancellationToken);

        //BusinessRule call
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"API Error: {response.StatusCode}");
        }

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Domain.Models.Object>>(jsonResponse);

        return result ?? new List<Domain.Models.Object>();
    }
    public async Task<Domain.Models.Object> GetObjectByIdAsync(string objectId, CancellationToken cancellationToken = default)
    {
        var requestUri = $"{_urlSetting.BaseUrl}objects/{objectId}";

        var response = await _client.GetAsync(requestUri, cancellationToken);
        //Check API 
        if (!response.IsSuccessStatusCode)
            throw new Exception($"API Error: {response.StatusCode}");


        //Try Deserialize
        var jsonResponse = await response.Content.ReadAsStringAsync();

        //Console.WriteLine("JSON Response: " + jsonResponse);

        try
        {
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Domain.Models.Object>(jsonResponse);

             if (result == null)
                throw new Exception($"Object with ID {objectId} not found.");

            return result;
        }
        catch (JsonException ex)
        {
             throw new Exception($"Error deserializing response: {ex.Message}", ex);
        }
    }



    private List<Domain.Models.Object> filterByName(List<Domain.Models.Object> objects, string? nameFilter)
    {
        if (string.IsNullOrEmpty(nameFilter))
        {
            return objects;
        }

        return objects.Where(obj => obj.Name != null &&
                                     obj.Name.Contains(nameFilter, StringComparison.OrdinalIgnoreCase)).ToList();
    }


}