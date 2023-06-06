using System.Diagnostics.CodeAnalysis;
using ChatbotProject.Common.Domain.Models.Responses;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Flurl.Serialization.TextJson;
using Microsoft.Extensions.Options;
using Polly;
using WhatsappBroker.Domain.Models.Models;
using WhatsappBroker.Domain.Models.Requests;
using WhatsappBroker.Domain.Models.Settings;
using WhatsappBroker.Infrastructure.Agents.Interfaces;
using WhatsappBroker.Utilities.Constants;

namespace WhatsappBroker.Infrastructure.Interfaces;

[ExcludeFromCodeCoverage]
public class WhatsappAgent : IWhatsappAgent
{
    private readonly string _token;

    public WhatsappAgent(IOptions<Settings> config)
    {
        _token = config.Value.WhatsappToken;
    }

    public async Task<MessageResponse> SendMessage(WhatsappMessageRequest request)
    {
        try
        {
            var response = await Policy
                .Handle<FlurlHttpException>()
                .RetryAsync(3)
                .ExecuteAsync(() =>
                {
                    var flurlRequest = Constants.WHATSAPP_API_URL
                        .AppendPathSegment("/v16.0/117727054549939/messages")
                        .WithHeader("Authorization", $"Bearer {_token}");
                    flurlRequest.Settings = new FlurlHttpSettings()
                    {
                        JsonSerializer = new TextJsonSerializer()
                    };

                    return flurlRequest
                        .PostJsonAsync(request)
                        .ReceiveJson<MessageResponse>();
                });

            return response;
        }
        catch(FlurlHttpException ex)
        {
            var errString = await ex.Call.HttpResponseMessage.Content.ReadAsStringAsync();
            throw ex;
        }
    }
}