namespace Pharmatrack.Client.Layouts;

using Microsoft.AspNetCore.Components;
using Pharmatrack.Client.Services;

public partial class MainLayout : LayoutComponentBase, IDisposable
{
    [Inject]
    protected AppStateService AppState { get; set; } = default!;

    protected override void OnInitialized()
    {
        AppState.OnChange += StateHasChanged;
    }

    public void Dispose()
    {
        AppState.OnChange -= StateHasChanged;
        GC.SuppressFinalize(this);
    }
}
