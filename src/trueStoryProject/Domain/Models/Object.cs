using Core.Persistence.Repositories;
using Newtonsoft.Json;

namespace Domain.Models;

public class Object:Entity
{
    [JsonProperty("name")]
    public required string Name { get; set; }

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
