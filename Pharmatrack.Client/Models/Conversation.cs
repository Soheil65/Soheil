namespace Pharmatrack.Client.Models;

public class Conversation
{
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public string LastMessagePreview { get; set; } = string.Empty;
    public DateTime LastTimestamp { get; set; }
    public int UnreadCount { get; set; }
}
