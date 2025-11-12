using Pharmatrack.Client.Models;

namespace Pharmatrack.Client.Services;

public class ChatService
{
    private readonly List<Conversation> _conversations;
    private readonly Dictionary<string, List<ChatMessage>> _messageHistory;
    private const string CurrentUserId = "me";

    public ChatService()
    {
        // Seed conversations
        _conversations = new List<Conversation>
        {
            new Conversation
            {
                UserId = "user1",
                UserName = "Dr. Sarah Johnson",
                AvatarUrl = "images/avatars/user1.svg",
                LastMessagePreview = "The inventory report looks good!",
                LastTimestamp = DateTime.UtcNow.AddMinutes(-5),
                UnreadCount = 2
            },
            new Conversation
            {
                UserId = "user2",
                UserName = "Mike Chen",
                AvatarUrl = "images/avatars/user2.svg",
                LastMessagePreview = "Can you review the prescription?",
                LastTimestamp = DateTime.UtcNow.AddMinutes(-20),
                UnreadCount = 1
            },
            new Conversation
            {
                UserId = "user3",
                UserName = "Emma Wilson",
                AvatarUrl = "images/avatars/user3.svg",
                LastMessagePreview = "Thanks for your help!",
                LastTimestamp = DateTime.UtcNow.AddHours(-3),
                UnreadCount = 0
            },
            new Conversation
            {
                UserId = "user4",
                UserName = "James Martinez",
                AvatarUrl = "images/avatars/user4.svg",
                LastMessagePreview = "See you tomorrow",
                LastTimestamp = DateTime.UtcNow.AddHours(-5),
                UnreadCount = 0
            },
            new Conversation
            {
                UserId = "user5",
                UserName = "Linda Brown",
                AvatarUrl = "images/avatars/user5.svg",
                LastMessagePreview = "Order has been approved",
                LastTimestamp = DateTime.UtcNow.AddDays(-1),
                UnreadCount = 0
            }
        };

        // Seed message history
        _messageHistory = new Dictionary<string, List<ChatMessage>>
        {
            ["user1"] = new List<ChatMessage>
            {
                new ChatMessage
                {
                    Id = "m1",
                    FromUserId = "user1",
                    ToUserId = CurrentUserId,
                    Text = "Hi! Have you checked the latest inventory report?",
                    SentAt = DateTime.UtcNow.AddHours(-2),
                    IsMine = false
                },
                new ChatMessage
                {
                    Id = "m2",
                    FromUserId = CurrentUserId,
                    ToUserId = "user1",
                    Text = "Yes, I reviewed it this morning. Everything looks accurate.",
                    SentAt = DateTime.UtcNow.AddHours(-1).AddMinutes(-50),
                    IsMine = true
                },
                new ChatMessage
                {
                    Id = "m3",
                    FromUserId = "user1",
                    ToUserId = CurrentUserId,
                    Text = "Great! Can we schedule a meeting to discuss the Q4 projections?",
                    SentAt = DateTime.UtcNow.AddHours(-1).AddMinutes(-45),
                    IsMine = false
                },
                new ChatMessage
                {
                    Id = "m4",
                    FromUserId = CurrentUserId,
                    ToUserId = "user1",
                    Text = "Sure, how about tomorrow at 2 PM?",
                    SentAt = DateTime.UtcNow.AddMinutes(-10),
                    IsMine = true
                },
                new ChatMessage
                {
                    Id = "m5",
                    FromUserId = "user1",
                    ToUserId = CurrentUserId,
                    Text = "The inventory report looks good!",
                    SentAt = DateTime.UtcNow.AddMinutes(-5),
                    IsMine = false
                }
            },
            ["user2"] = new List<ChatMessage>
            {
                new ChatMessage
                {
                    Id = "m6",
                    FromUserId = "user2",
                    ToUserId = CurrentUserId,
                    Text = "Hello, I need help with a prescription verification.",
                    SentAt = DateTime.UtcNow.AddMinutes(-30),
                    IsMine = false
                },
                new ChatMessage
                {
                    Id = "m7",
                    FromUserId = CurrentUserId,
                    ToUserId = "user2",
                    Text = "Of course! What do you need?",
                    SentAt = DateTime.UtcNow.AddMinutes(-25),
                    IsMine = true
                },
                new ChatMessage
                {
                    Id = "m8",
                    FromUserId = "user2",
                    ToUserId = CurrentUserId,
                    Text = "Can you review the prescription?",
                    SentAt = DateTime.UtcNow.AddMinutes(-20),
                    IsMine = false
                }
            },
            ["user3"] = new List<ChatMessage>
            {
                new ChatMessage
                {
                    Id = "m9",
                    FromUserId = CurrentUserId,
                    ToUserId = "user3",
                    Text = "I've completed the medication tracking report.",
                    SentAt = DateTime.UtcNow.AddHours(-4),
                    IsMine = true
                },
                new ChatMessage
                {
                    Id = "m10",
                    FromUserId = "user3",
                    ToUserId = CurrentUserId,
                    Text = "Thanks for your help!",
                    SentAt = DateTime.UtcNow.AddHours(-3),
                    IsMine = false
                }
            },
            ["user4"] = new List<ChatMessage>
            {
                new ChatMessage
                {
                    Id = "m11",
                    FromUserId = "user4",
                    ToUserId = CurrentUserId,
                    Text = "Meeting at 10 AM tomorrow?",
                    SentAt = DateTime.UtcNow.AddHours(-6),
                    IsMine = false
                },
                new ChatMessage
                {
                    Id = "m12",
                    FromUserId = CurrentUserId,
                    ToUserId = "user4",
                    Text = "Perfect, I'll be there!",
                    SentAt = DateTime.UtcNow.AddHours(-5).AddMinutes(-30),
                    IsMine = true
                },
                new ChatMessage
                {
                    Id = "m13",
                    FromUserId = "user4",
                    ToUserId = CurrentUserId,
                    Text = "See you tomorrow",
                    SentAt = DateTime.UtcNow.AddHours(-5),
                    IsMine = false
                }
            },
            ["user5"] = new List<ChatMessage>
            {
                new ChatMessage
                {
                    Id = "m14",
                    FromUserId = "user5",
                    ToUserId = CurrentUserId,
                    Text = "Order has been approved",
                    SentAt = DateTime.UtcNow.AddDays(-1),
                    IsMine = false
                }
            }
        };
    }

    public IEnumerable<Conversation> GetConversations()
    {
        return _conversations.OrderByDescending(c => c.LastTimestamp);
    }

    public IEnumerable<ChatMessage> GetMessages(string userId)
    {
        return _messageHistory.TryGetValue(userId, out var messages) 
            ? messages 
            : Enumerable.Empty<ChatMessage>();
    }

    public ChatMessage SendMessage(string toUserId, string text)
    {
        var message = new ChatMessage
        {
            Id = Guid.NewGuid().ToString(),
            FromUserId = CurrentUserId,
            ToUserId = toUserId,
            Text = text,
            SentAt = DateTime.UtcNow,
            IsMine = true
        };

        if (!_messageHistory.ContainsKey(toUserId))
        {
            _messageHistory[toUserId] = new List<ChatMessage>();
        }

        _messageHistory[toUserId].Add(message);

        // Update conversation
        var conversation = _conversations.FirstOrDefault(c => c.UserId == toUserId);
        if (conversation != null)
        {
            conversation.LastMessagePreview = text;
            conversation.LastTimestamp = message.SentAt;
        }

        return message;
    }
}
