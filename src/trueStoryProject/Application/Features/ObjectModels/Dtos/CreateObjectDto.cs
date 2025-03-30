﻿using System.Text.Json.Serialization;

namespace Application.Features.MockAPIModels.Dtos;

public class CreateObjectDto
{
    public string Name { get; set; }

    [JsonPropertyName("Data")]
    public Dictionary<string, object> Data { get; set; }
}
