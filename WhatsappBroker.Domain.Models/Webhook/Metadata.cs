using System.Text.Json.Serialization;

namespace WhatsappBroker.Domain.Models.Models.Webhook;

public  class Metadata
{
    [JsonPropertyName("display_phone_number")]
    public string DisplayPhoneNumber { get; set; }

    [JsonPropertyName("phone_number_id")]
    public string PhoneNumberId { get; set; }
}