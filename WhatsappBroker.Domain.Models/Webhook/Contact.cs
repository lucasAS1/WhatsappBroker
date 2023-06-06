using System.Text.Json.Serialization;

namespace WhatsappBroker.Domain.Models.Models.Webhook;

public class Contact
{
    [JsonPropertyName("profile")]
    public Profile Profile { get; set; }

    [JsonPropertyName("wa_id")]
    public string WaId { get; set; }
}