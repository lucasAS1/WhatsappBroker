using ChatbotProject.Common.Domain.Models.Requests;
using RabbitMQ.Client.Core.DependencyInjection.Services.Interfaces;
using WhatsappBroker.Domain.Models.Models.Webhook;

namespace WhatsappBroker.Domain.Facade;

public class WhatsappFacade : IWhatsappFacade
{
    private readonly IProducingService _queueService;

    public WhatsappFacade(IProducingService queueService)
    {
        _queueService = queueService;
    }

    public void SendMessage(WhatsappWebhookRequest message)
    {
        var valueMessage = message.Entry[0].Changes[0].Value.Messages[0];
        var messageRequest = new MessageRequest()
        {
            Text = valueMessage.Type == "text" ? valueMessage.Text.Body : 
                valueMessage.Interactive.Type == "button_reply" ? valueMessage.Interactive.ButtonReply.Title : valueMessage.Interactive.ListReply.Title,
            ChatId = message.Entry[0].Changes[0].Value.Contacts[0].WaId
        };
        
        _queueService.Send(messageRequest,"whatsapp-service","whatsapp-to-service");
    }
}

public interface IWhatsappFacade
{
    public void SendMessage(WhatsappWebhookRequest message);
}