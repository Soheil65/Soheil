namespace Pharmatrack.Client.SharedComponents;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Pharmatrack.Client.Models;

public partial class NotificationPanel : UiComponentBase
{
    [Parameter]
    public bool IsOpen { get; set; }

    [Parameter]
    public IEnumerable<NotificationModel>? Notifications { get; set; }

    [Parameter]
    public EventCallback OnClose { get; set; }

    private ElementReference panelElement;

    protected override void OnInitializedCore()
    {
        Nav.LocationChanged += HandleLocationChanged;
    }

    private void HandleLocationChanged(object? sender, LocationChangedEventArgs e)
    {
        if (IsOpen)
        {
            _ = Close();
        }
    }

    protected async Task Close()
    {
        await OnClose.InvokeAsync();
    }

    protected async Task ViewAllNotifications()
    {
        Nav.NavigateTo("/messages");
        await Close();
    }

    protected override void DisposeCore()
    {
        Nav.LocationChanged -= HandleLocationChanged;
    }
}
