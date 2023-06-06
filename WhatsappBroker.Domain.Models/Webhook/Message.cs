using System.Text.Json.Serialization;
using WhatsappBroker.Domain.Models.Requests;

namespace WhatsappBroker.Domain.Models.Models.Webhook;

public class Message
{
    [JsonPropertyName("from")]
    public string From { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("timestamp")]
    public string Timestamp { get; set; }

    [JsonPropertyName("text")]
    public Text? Text { get; set; }
    
    [JsonPropertyName("interactive")]
    public Interactive? Interactive { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}