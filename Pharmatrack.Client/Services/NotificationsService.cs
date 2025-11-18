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
                FromUserId = "user1",
                FromUserName = "Dr. Sarah Johnson",
                AvatarUrl = "images/avatars/user1.svg",
                MessagePreview = "mentioned you in Pharmacy Inventory project",
                MessageId = "m3",
                Timestamp = DateTime.UtcNow.AddMinutes(-5),
                IsRead = false
            },
            new NotificationModel
            {
                Id = "2",
                FromUserId = "user2",
                FromUserName = "Mike Chen",
                AvatarUrl = "images/avatars/user2.svg",
                MessagePreview = "commented on your prescription review",
                MessageId = "m8",
                Timestamp = DateTime.UtcNow.AddMinutes(-15),
                IsRead = false
            },
            new NotificationModel
            {
                Id = "3",
                FromUserId = "user3",
                FromUserName = "Emma Wilson",
                AvatarUrl = "images/avatars/user3.svg",
                MessagePreview = "assigned you to new medication tracking task",
                MessageId = "m10",
                Timestamp = DateTime.UtcNow.AddHours(-2),
                IsRead = false
            },
            new NotificationModel
            {
                Id = "4",
                FromUserId = "user4",
                FromUserName = "James Martinez",
                AvatarUrl = "images/avatars/user4.svg",
                MessagePreview = "shared a document with you: Drug Interactions Guide",
                MessageId = "m13",
                Timestamp = DateTime.UtcNow.AddHours(-4),
                IsRead = true
            },
                new NotificationModel
                {
                    Id = "5",
                    FromUserId = "user5",
                    FromUserName = "Linda Brown",
                    AvatarUrl = "images/avatars/user5.svg",
                    MessagePreview = "approved your trip request",
                    MessageId = "m14",
                    Timestamp = DateTime.UtcNow.AddDays(-1),
                    IsRead = true
                }
        };
    }

    public IEnumerable<NotificationModel> GetRecent(int count)
    {
        return _notifications.OrderByDescending(n => n.Timestamp).Take(count);
    }

    public void MarkAsRead(string notificationId)
    {
        var notification = _notifications.FirstOrDefault(n => n.Id == notificationId);
        if (notification != null)
        {
            notification.IsRead = true;
            NotifyStateChanged();
        }
    }

    public void MarkAllRead()
    {
        foreach (var notification in _notifications)
        {
            notification.IsRead = true;
        }
        NotifyStateChanged();
    }

    public bool HasUnread => _notifications.Any(n => !n.IsRead);

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}
