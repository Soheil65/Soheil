namespace Pharmatrack.BlazorServer.Components.Pages.TripDashboard;
using Microsoft.AspNetCore.Components;
using Pharmatrack.BlazorServer.Services;
using Pharmatrack.BlazorServer.Utility;

public partial class TripDashboard : UiComponentBase
{
    [Inject]
    protected ApiClientService ApiClient { get; set; } = default!;
    
    [Parameter]
    public string Class { get; set; }

    protected override async Task OnInitializedCoreAsync()
    {
    }
}
