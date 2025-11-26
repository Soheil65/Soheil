namespace Pharmatrack.Client.SharedComponents;

using Microsoft.AspNetCore.Components;
using Pharmatrack.Client.Models;
using Pharmatrack.Client.Services;

public partial class NotificationItem : UiComponentBase
{
    [Parameter]
    public NotificationModel Notification { get; set; } = default!;

    [Parameter]
    public EventCallback OnNavigate { get; set; }

    [Inject]
    protected NotificationsService NotificationsService { get; set; } = default!;

    protected async Task HandleClick()
    {
        // Mark notification as read
        NotificationsService.MarkAsRead(Notification.Id);

        // Navigate to messages with deep-link
        Nav.NavigateTo($"/messages?userId={Notification.FromUserId}&messageId={Notification.MessageId}");

        // Notify parent to close the panel
        await OnNavigate.InvokeAsync();
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
