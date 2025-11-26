namespace Pharmatrack.Client.Pages.Messages;

using Microsoft.AspNetCore.Components;
using Pharmatrack.Client.Models;

public partial class ConversationsList : UiComponentBase
{
    [Parameter]
    public IEnumerable<Conversation>? Conversations { get; set; }

    [Parameter]
    public string? SelectedUserId { get; set; }

    [Parameter]
    public EventCallback<string> OnSelect { get; set; }

    protected async Task HandleSelect(string userId)
    {
        await OnSelect.InvokeAsync(userId);
    }

    protected string GetRelativeTime(DateTime timestamp)
    {
        var diff = DateTime.UtcNow - timestamp;

        if (diff.TotalMinutes < 1)
            return "now";
        if (diff.TotalMinutes < 60)
            return $"{(int)diff.TotalMinutes}m";
        if (diff.TotalHours < 24)
            return $"{(int)diff.TotalHours}h";
        if (diff.TotalDays < 7)
            return $"{(int)diff.TotalDays}d";
        
        return timestamp.ToLocalTime().ToString("MMM d");
    }
}
