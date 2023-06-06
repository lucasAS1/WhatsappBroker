using System.Text.Json.Serialization;
using ChatbotProject.Common.Domain.Models.Requests;

namespace WhatsappBroker.Domain.Models.Requests;

public class WhatsappMessageRequest
{
    public WhatsappMessageRequest(MessageRequest messageRequest)
    {
        To = messageRequest.ChatId;

        if (messageRequest.InteractiveMessage is not null)
        {
            Type = "interactive";
            AddInteractiveMessage(messageRequest);
            return;
        }

        Text = new Text()
        {
            Body = messageRequest.Text,
            PreviewUrl = messageRequest.Text.Contains("http")
        };
    }

    private void AddInteractiveMessage(MessageRequest messageRequest)
    {
        Interactive = new Interactive()
        {
            Body = new Body()
            {
                Text = messageRequest.Text
            }
        };

        if (messageRequest.InteractiveMessage.Type == InteractiveMessageType.Button)
        {
            Interactive.Type = "button";
            Interactive.Action = new Action()
            {
                Buttons = new List<Button>()
            };

            for (var i = 0; i < messageRequest.InteractiveMessage.Options.Count; i++)
            {
                Interactive.Action.Buttons.Add(new Button()
                {
                    Reply = new Reply()
                    {
                        Id = $"{i}",
                        Title = messageRequest.InteractiveMessage.Options[i]
                    }
                });
            }

            return;
        }

        Interactive.Type = "list";
        Interactive.Action = new Action()
        {
            Button = "Clique aqui",
            Sections = new List<Section>()
            {
                new ()
                {
                    Title = "Escolha uma opção",
                    Rows = new List<Row>()
                }
            }
        };

        for (var i = 0; i < messageRequest.InteractiveMessage.Options.Count; i++)
        {
            Interactive.Action.Sections[0].Rows.Add(new Row()
            {
                Id = $"{i}",
                Title = messageRequest.InteractiveMessage.Options[i]
            });
        }
    }

    [JsonPropertyName("messaging_product")]
    public string MessagingProduct { get; init; } = "whatsapp";

    [JsonPropertyName("to")]
    public string To { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("text")]
    public Text? Text { get; set; }
    
    [JsonPropertyName("template")]
    public Template? Template { get; set; }
    
    [JsonPropertyName("interactive")]
    public Interactive? Interactive { get; set; }
}

public class Interactive
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("body")]
    public Body? Body { get; set; }

    [JsonPropertyName("action")]
    public Action? Action { get; set; }
    
    [JsonPropertyName("button_reply")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Reply? ButtonReply { get; set; }
    
    [JsonPropertyName("list_reply")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Row? ListReply { get; set; }
}

public class Body
{
    [JsonPropertyName("text")]
    public string Text { get; set; }
}

public class Action
{
    [JsonPropertyName("button")]
    public string Button { get; set; }
    
    [JsonPropertyName("buttons")]
    public List<Button> Buttons { get; set; }
    
    [JsonPropertyName("sections")]
    public List<Section> Sections { get; set; }
}

public class Section
{
    [JsonPropertyName("rows")] 
    public List<Row> Rows { get; set; }
    
    [JsonPropertyName("title")]
    public string Title { get; set; }
}

public class Row
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}

public class Button
{
    [JsonPropertyName("type")] public string Type { get; set; } = "reply";

    [JsonPropertyName("reply")]
    public Reply? Reply { get; set; }
}

public class Reply
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }
}