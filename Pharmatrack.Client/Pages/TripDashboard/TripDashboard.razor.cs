namespace Pharmatrack.Client.Pages.TripDashboard;
using Microsoft.AspNetCore.Components;
using Pharmatrack.Client.Models;
using Pharmatrack.Client.Services;
using Pharmatrack.ViewModels.Trip;

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
