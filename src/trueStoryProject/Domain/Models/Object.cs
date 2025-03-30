using Core.Persistence.Repositories;
using System.Text.Json.Serialization;

namespace Domain.Models;

public class Object:Entity
{
    public string Name { get; set; }

    [JsonPropertyName("Data")]
    public Dictionary<string, object> Data { get; set; }

    public Object()
    {
        
    }
    public Object(int id,string name)
    {
        Id=id;
        Name=name; 
    }

}
