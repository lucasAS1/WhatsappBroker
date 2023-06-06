using System.Text.Json.Serialization;

namespace WhatsappBroker.Domain.Models.Models.Webhook;

public class Change
{
    [JsonPropertyName("value")]
    public Value Value { get; set; }

    [JsonPropertyName("field")]
    public string Field { get; set; }
}