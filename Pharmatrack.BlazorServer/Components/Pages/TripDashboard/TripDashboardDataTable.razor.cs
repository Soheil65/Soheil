using DevExpress.Data.Mask.Internal;
using Microsoft.AspNetCore.Components;
using Pharmatrack.API.Services;
using Pharmatrack.BlazorServer.Services;
using Pharmatrack.BlazorServer.Utility;
using Pharmatrack.ViewModels.Trip;
using System;

namespace Pharmatrack.BlazorServer.Components.Pages.TripDashboard;

public partial class TripDashboardDataTable : UiComponentBase
{
    [Inject]
    protected TripDashboardService TripDashboardService { get; set; } = default!;

    [Inject]
    protected ApiClientService ApiClient { get; set; } = default!;

    [Parameter]
    public string Class { get; set; } = string.Empty;

    public IEnumerable<TripResponseViewModel>? Trips { get; set; } = null;

    // Paging state
    int PageIndex { get; set; } = 0;  // zero-based
    int PageSize { get; set; } = 15;

    bool IsLoading { get; set; }

    bool IsMapPopupVisible { get; set; }

    List<(double lat, double lon)> MapStops { get; set; } = new();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender)
            return;

        // subscribe to event
        TripDashboardService.TripsChanged += OnTripsChanged;

        // initial state (in case service already has data)
        Trips = TripDashboardService.Trips;
    }

    private async Task OnPageSizeChanged(int newSize)
    {
        PageSize = newSize;
        PageIndex = 0;
        await TripDashboardService.GetTripsByPaginationAsync(PageIndex + 1, PageSize);
    }

    private void ShowMap(TripResponseViewModel trip)
    {
        // Demo coordinates (3 stops)
        MapStops = new List<(double, double)>
        {
            (37.7749, -122.4194),
            (37.7849, -122.4094),
            (37.7949, -122.3994)
        };
        IsMapPopupVisible = true;
    }

    private Task OnMapVisibleChanged(bool value)
    {
        IsMapPopupVisible = value;
        if (!value)
        {
            MapStops.Clear();
        }
        return Task.CompletedTask;
    }

    private void OnTripsChanged()
    {
        Trips = TripDashboardService.Trips;
        _ = InvokeAsync(StateHasChanged);
    }

    protected override ValueTask DisposeCoreAsync()
    {
        TripDashboardService.TripsChanged -= OnTripsChanged;
        return base.DisposeCoreAsync();
    }
}
