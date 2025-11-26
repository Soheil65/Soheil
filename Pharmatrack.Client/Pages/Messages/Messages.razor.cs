namespace Pharmatrack.Client.Pages.Messages;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Pharmatrack.Client.Models;
using Pharmatrack.Client.Services;

public partial class Messages : UiComponentBase
{
    [Inject]
    protected ChatService ChatService { get; set; } = default!;

    private IEnumerable<Conversation>? conversations;
    private string? selectedUserId;
    private string? messageIdToHighlight;

    protected override void OnInitializedCore()
    {
        LoadConversations();
        ParseQueryParameters();
        
        // Select first conversation by default if no query params
        if (string.IsNullOrEmpty(selectedUserId) && conversations?.Any() == true)
        {
            selectedUserId = conversations.First().UserId;
        }
    }

    private void ParseQueryParameters()
    {
        var uri = new Uri(Nav.Uri);
        var queryParams = QueryHelpers.ParseQuery(uri.Query);

        if (queryParams.TryGetValue("userId", out var userIdValues))
        {
            selectedUserId = userIdValues.FirstOrDefault();
        }

        if (queryParams.TryGetValue("messageId", out var messageIdValues))
        {
            messageIdToHighlight = messageIdValues.FirstOrDefault();
        }
    }

    private void LoadConversations()
    {
        conversations = ChatService.GetConversations();
    }

    protected void HandleConversationSelect(string userId)
    {
        selectedUserId = userId;
    }

    protected void HandleMessageSent()
    {
        // Refresh conversations to update last message preview
        LoadConversations();
        StateHasChanged();
    }
}
