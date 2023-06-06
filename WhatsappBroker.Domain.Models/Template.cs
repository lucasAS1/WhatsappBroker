using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WhatsappBroker.Domain.Models;

public class Template
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("language")]
    public Language Language { get; set; }
}