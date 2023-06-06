using ChatbotProject.Common.Domain.Models.Requests;
using ChatbotProject.Common.Domain.Models.Responses;

namespace WhatsappBroker.Domain.Services.Interfaces;

public interface IWhatsappService
{
    public Task<MessageResponse> SendMessageAsync(MessageRequest message);
}