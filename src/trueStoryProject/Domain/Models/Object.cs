using Core.Persistence.Repositories;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Domain.Models;

public class Object:Entity
{
    [JsonProperty("name")]
    public required string Name { get; set; }

    //[JsonPropertyName("Data")]
    //public Dictionary<string, object> Data { get; set; }
    
    [JsonProperty("data")]
    public required Data Data { get; set; }

    public Object()
    {
        
    }
    public Object(string id,string name)
    {
        Id=id;
        Name=name; 
    }

}
