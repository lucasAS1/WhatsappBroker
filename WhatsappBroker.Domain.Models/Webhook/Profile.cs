using System.Text.Json.Serialization;

namespace WhatsappBroker.Domain.Models.Models.Webhook;

public class Profile
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
}