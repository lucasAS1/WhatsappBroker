using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WhatsappBroker.Domain.Models;

public class Language
{
    [JsonPropertyName("code")]
    public string Code { get; set; }
}