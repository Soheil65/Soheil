namespace Pharmatrack.Client.Pages.Messages;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

public partial class MessageInput : UiComponentBase
{
    [Parameter]
    public EventCallback<string> OnSendMessage { get; set; }

    private string messageText = string.Empty;

    protected async Task SendMessage()
    {
        if (!string.IsNullOrWhiteSpace(messageText))
        {
            await OnSendMessage.InvokeAsync(messageText);
            messageText = string.Empty;
        }
    }

    protected async Task HandleKeyDown(KeyboardEventArgs e)
    {
        if (e.Key == "Enter" && !e.ShiftKey)
        {
            await SendMessage();
        }
    }
}
