using System.Text.Json.Serialization;

namespace WhatsappBroker.Domain.Models.Models.Webhook;

    public class WhatsappWebhookRequest
    {
        [JsonPropertyName("object")]
        public string Object { get; set; }

        [JsonPropertyName("entry")]
        public List<Entry> Entry { get; set; }
    }