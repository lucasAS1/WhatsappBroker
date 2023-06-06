using System.Text.Json.Serialization;

namespace WhatsappBroker.Domain.Models;

public class Text
{
    [JsonPropertyName("body")]
    public string Body { get; set; }

    [JsonPropertyName("preview_url")] 
    public bool? PreviewUrl { get; set; } = false;
}