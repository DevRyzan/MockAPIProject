using Domain.Models;
using Newtonsoft.Json;

namespace Application.Features.ObjectModels.Dtos;

public class ObjectListDto
{
    [JsonProperty("name")]
    public required string Name { get; set; }
 
    [JsonProperty("data")]
    public required Data Data { get; set; }
}
