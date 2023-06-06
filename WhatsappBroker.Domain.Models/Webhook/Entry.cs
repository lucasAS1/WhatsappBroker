using System.Text.Json.Serialization;

namespace WhatsappBroker.Domain.Models.Models.Webhook;

public class Entry
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("changes")]
    public List<Change> Changes { get; set; }
}