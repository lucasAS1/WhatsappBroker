using ChatbotProject.Common.Domain.Models.Requests;
using RabbitMQ.Client.Core.DependencyInjection.MessageHandlers;
using RabbitMQ.Client.Core.DependencyInjection.Models;
using WhatsappBroker.Domain.Services.Interfaces;
using static System.Text.Encoding;
using static Newtonsoft.Json.JsonConvert;

namespace WhatsappBroker.Application.WebApi.Handlers;

public class WhatsappMessageHandler : IAsyncMessageHandler
{
    private readonly IWhatsappService _whatsappService;

    public WhatsappMessageHandler(IWhatsappService whatsappService)
    {
        _whatsappService = whatsappService;
    }

    public async Task Handle(MessageHandlingContext context, string matchingRoute)
    {
        var message = UTF8.GetString(context.Message.Body.ToArray());
        var messageRequest = DeserializeObject<MessageRequest>(message);
        
        await _whatsappService.SendMessageAsync(messageRequest);
    }
}