using ChatbotProject.Common.Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using WhatsappBroker.Domain.Services.Interfaces;

namespace WhatsappBroker.Application.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WhatsappBroker : ControllerBase
{
    private readonly IWhatsappService _whatsappService;

    public WhatsappBroker(IWhatsappService whatsappService)
    {
        _whatsappService = whatsappService;
    }
    
    [HttpPost]
    public async Task<IActionResult> SendMessage([FromQuery] string chatId, [FromQuery] string text)
    {
        var message = new MessageRequest()
        {
            Text = text,
            ChatId = chatId
        };

        var response = await _whatsappService.SendMessageAsync(message);
        
        return new JsonResult(response);
    }
}