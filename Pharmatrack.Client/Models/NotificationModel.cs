namespace Pharmatrack.Client.Models;

public class NotificationModel
{
    public string Id { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string MessagePreview { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
    public bool IsRead { get; set; }
}
