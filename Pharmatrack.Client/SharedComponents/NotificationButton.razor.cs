namespace Pharmatrack.Client.SharedComponents;

using Microsoft.AspNetCore.Components;
using Pharmatrack.Client.Models;
using Pharmatrack.Client.Services;

public partial class NotificationButton : UiComponentBase
{
    [Inject]
    protected NotificationsService NotificationsService { get; set; } = default!;

    private bool isPanelOpen = false;
    private IEnumerable<NotificationModel>? notifications;

    protected override void OnInitializedCore()
    {
        NotificationsService.OnChange += StateHasChanged;
        LoadNotifications();
    }

    private void LoadNotifications()
    {
        notifications = NotificationsService.GetRecent(10);
    }

    protected void TogglePanel()
    {
        isPanelOpen = !isPanelOpen;
        if (isPanelOpen)
        {
            LoadNotifications();
        }
    }

    protected void ClosePanel()
    {
        isPanelOpen = false;
    }

    protected override void DisposeCore()
    {
        NotificationsService.OnChange -= StateHasChanged;
    }
}
