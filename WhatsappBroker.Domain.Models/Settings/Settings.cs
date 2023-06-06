using ChatbotProject.Common.Domain.Models.Settings;

namespace WhatsappBroker.Domain.Models.Settings;

public class Settings : ApiSettings
{
    public string WhatsappToken { get; set; }
}