using System.Diagnostics.CodeAnalysis;
using ChatbotProject.Common.Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using WhatsappBroker.Domain.Facade;
using WhatsappBroker.Domain.Models.Models.Webhook;
using WhatsappBroker.Domain.Services.Interfaces;

namespace WhatsappBroker.Application.WebApi.Controllers;

[ApiController]
[ExcludeFromCodeCoverage]
public class WebhookController : ControllerBase
{
    private readonly IWhatsappFacade _whatsappFacade;

    public WebhookController(IWhatsappFacade whatsappFacade)
    {
        _whatsappFacade = whatsappFacade;
    }

    [HttpPost]
    [Route("ReceiveMessageFromWhatsapp")]
    public IActionResult ReceiveMessageFromTelegram([FromBody]WhatsappWebhookRequest message)
    {
        _whatsappFacade.SendMessage(message);

        return Ok();
    }

    [HttpGet]
    [Route("ReceiveMessageFromWhatsapp")]
    public IActionResult ConfirmWebhook()
    {
        return Ok($"{Request.Query["hub.challenge"]}");
    }
}