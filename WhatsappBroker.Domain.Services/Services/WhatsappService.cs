using ChatbotProject.Common.Domain.Models.Requests;
using ChatbotProject.Common.Domain.Models.Responses;
using WhatsappBroker.Domain.Models.Requests;
using WhatsappBroker.Domain.Services.Interfaces;
using WhatsappBroker.Infrastructure.Agents.Interfaces;

namespace WhatsappBroker.Domain.Services.Services;

public class WhatsappService : IWhatsappService
{
    private readonly IWhatsappAgent _whatsappAgent;

    public WhatsappService(IWhatsappAgent whatsappAgent)
    {
        _whatsappAgent = whatsappAgent;
    }

    public async Task<MessageResponse> SendMessageAsync(MessageRequest message)
    {
        var messageRequest = new WhatsappMessageRequest(message);
        var response = await _whatsappAgent.SendMessage(messageRequest);
        
        return response;
    }
}