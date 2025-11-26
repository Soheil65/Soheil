namespace Pharmatrack.Client.Pages.Messages;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Pharmatrack.Client.Models;
using Pharmatrack.Client.Services;

public partial class ChatWindow : UiComponentBase
{
    [Parameter]
    public string? SelectedUserId { get; set; }

    [Parameter]
    public string? MessageIdToHighlight { get; set; }

    [Parameter]
    public EventCallback OnMessageSent { get; set; }

    [Inject]
    protected ChatService ChatService { get; set; } = default!;

    private Conversation? selectedConversation;
    private List<ChatMessage> messages = new();
    private ElementReference messagesContainer;
    private string? highlightedMessageId;

    protected override void OnParametersSetCore()
    {
        if (!string.IsNullOrEmpty(SelectedUserId))
        {
            LoadConversation();
            LoadMessages();
        }
    }

    protected override async Task OnAfterRenderCoreAsync(bool firstRender)
    {
        if (!string.IsNullOrEmpty(MessageIdToHighlight) && messages.Any(m => m.Id == MessageIdToHighlight))
        {
            await ScrollToMessage(MessageIdToHighlight);
        }
    }

    private void LoadConversation()
    {
        selectedConversation = ChatService.GetConversations()
            .FirstOrDefault(c => c.UserId == SelectedUserId);
    }

    private void LoadMessages()
    {
        messages = ChatService.GetMessages(SelectedUserId!).ToList();
    }

    public async Task ScrollToMessage(string messageId)
    {
        try
        {
            highlightedMessageId = messageId;

            await base.JS.InvokeVoidAsync("scrollToId", $"msg-{messageId}");

            highlightedMessageId = null;

        }
        catch (Exception ex)
        {
            // Handle JS interop errors silently
            base.Logger.LogWarning(ex, "Failed to scroll to message {MessageId}", messageId);
        }
    }

    protected async Task HandleSendMessage(string text)
    {
        if (!string.IsNullOrEmpty(SelectedUserId))
        {
            var message = ChatService.SendMessage(SelectedUserId, text);
            messages.Add(message);
            await OnMessageSent.InvokeAsync();
           // base.StateHasChanged();
        }
    }

    protected string GetRelativeTime(DateTime timestamp)
    {
        var diff = DateTime.UtcNow - timestamp;

        if (diff.TotalMinutes < 1)
            return "just now";
        if (diff.TotalMinutes < 60)
            return $"{(int)diff.TotalMinutes} min ago";
        if (diff.TotalHours < 24)
            return $"{(int)diff.TotalHours}h ago";
        if (diff.TotalDays < 7)
            return $"{(int)diff.TotalDays}d ago";
        
        return timestamp.ToLocalTime().ToString("MMM d");
    }
}
