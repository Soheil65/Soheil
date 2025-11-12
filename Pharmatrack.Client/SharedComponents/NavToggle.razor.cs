namespace Pharmatrack.Client.SharedComponents;

using Microsoft.AspNetCore.Components;
using Pharmatrack.Client.Services;

public partial class NavToggle : UiComponentBase
{
    [Inject]
    protected AppStateService AppState { get; set; } = default!;

    protected void ToggleSidebar()
    {
        AppState.ToggleSidebar();
    }
}
