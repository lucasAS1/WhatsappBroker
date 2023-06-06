using ChatbotProject.Common.Domain.Models.Responses;
using WhatsappBroker.Domain.Models.Models;
using WhatsappBroker.Domain.Models.Requests;

namespace WhatsappBroker.Infrastructure.Agents.Interfaces;

public interface IWhatsappAgent
{
    public Task<MessageResponse> SendMessage(WhatsappMessageRequest request);
}