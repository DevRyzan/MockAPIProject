using Core.Persistence.Repositories;
using Newtonsoft.Json; 

namespace Domain.Models;

public class Data:Entity
{
    [JsonProperty(nameof(Year))]
    public required string Year { get; set; }

    [JsonProperty(nameof(Price))]
    public required string Price { get; set; }

    [JsonProperty("cpuModel")]
    public required string CpuModel { get; set; }

    [JsonProperty("hardDiskSize")]
    public required string HardDiskSize { get; set; }
}
