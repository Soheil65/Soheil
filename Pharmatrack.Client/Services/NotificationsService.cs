using Pharmatrack.Client.Models;

namespace Pharmatrack.Client.Services;

public class NotificationsService
{
    private readonly List<NotificationModel> _notifications;

    public NotificationsService()
    {
        // Seed sample notifications
        _notifications = new List<NotificationModel>
        {
            new NotificationModel
            {
                Id = "1",
                AvatarUrl = "images/avatars/user1.svg",
                Name = "Dr. Sarah Johnson",
                MessagePreview = "mentioned you in Pharmacy Inventory project",
                Timestamp = DateTime.UtcNow.AddMinutes(-5),
                IsRead = false
            },
            new NotificationModel
            {
                Id = "2",
                AvatarUrl = "images/avatars/user2.svg",
                Name = "Mike Chen",
                MessagePreview = "commented on your prescription review",
                Timestamp = DateTime.UtcNow.AddMinutes(-15),
                IsRead = false
            },
            new NotificationModel
            {
                Id = "3",
                AvatarUrl = "images/avatars/user3.svg",
                Name = "Emma Wilson",
                MessagePreview = "assigned you to new medication tracking task",
                Timestamp = DateTime.UtcNow.AddHours(-2),
                IsRead = false
            },
            new NotificationModel
            {
                Id = "4",
                AvatarUrl = "images/avatars/user4.svg",
                Name = "James Martinez",
                MessagePreview = "shared a document with you: Drug Interactions Guide",
                Timestamp = DateTime.UtcNow.AddHours(-4),
                IsRead = true
            },
            new NotificationModel
            {
                Id = "5",
                AvatarUrl = "images/avatars/user5.svg",
                Name = "Linda Brown",
                MessagePreview = "approved your medication order request",
                Timestamp = DateTime.UtcNow.AddDays(-1),
                IsRead = true
            }
        };
    }

    public IEnumerable<NotificationModel> GetRecent(int count)
    {
        return _notifications.OrderByDescending(n => n.Timestamp).Take(count);
    }

    public void MarkAllRead()
    {
        foreach (var notification in _notifications)
        {
            notification.IsRead = true;
        }
    }

    public bool HasUnread => _notifications.Any(n => !n.IsRead);

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}
