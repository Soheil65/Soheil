namespace Pharmatrack.Client.SharedComponents;

using Microsoft.AspNetCore.Components;
using Pharmatrack.Client.Services;

public partial class NavMenu : UiComponentBase
{
    [Inject]
    protected AppStateService AppState { get; set; } = default!;

    protected override void OnInitializedCore()
    {
        AppState.OnChange += StateHasChanged;
    }

    protected override void DisposeCore()
    {
        AppState.OnChange -= StateHasChanged;
    }
}
