using Microsoft.AspNetCore.Components;
using Pharmatrack.Client.Services;
using Pharmatrack.ViewModels.Trip;

namespace Pharmatrack.Client.Pages.TripDashboard;

public partial class TripDashboardDataTable : UiComponentBase
{
    [Inject]
    protected ApiClientService ApiClient { get; set; } = default!;

    [Parameter]
    public string Class { get; set; } = string.Empty;

    [Parameter]
    public IEnumerable<TripResponseViewModel>? Trips { get; set; } = null;

    [Parameter]
    public EventCallback<TripResponseViewModel?> OnTripSelected { get; set; }

    public TripResponseViewModel? SelectedTrip { get; set; }

    // Paging state
    int PageIndex { get; set; } = 0;  // zero-based
    int PageSize { get; set; } = 15;

    bool IsLoading { get; set; }

    bool IsMapPopupVisible { get; set; }

    List<(double lat, double lon)> MapStops { get; set; } = new();

    protected override async Task OnInitializedCoreAsync()
    {
        if (Trips == null || !Trips.Any())
        {
            await LoadPageAsync();
        }
    }

    private string? errorMessage;
    private async Task LoadPageAsync()
    {
        try
        {
             IsLoading = true;
            var response = await ApiClient.Trip.GetAllTripsAsync();

            if (response != null && response.Success && response.Data != null)
            {
                Trips = response.Data;
            }
            else
            {
                errorMessage = response?.Message ?? "Failed to load trips";
            }
        }
        catch (Exception ex)
        {
            errorMessage = $"Error: {ex.Message}";
            Logger.LogError(ex, "Failed to load trips");
        }
        finally
        {
            IsLoading = false;
        }
    }

    private async Task OnPageSizeChanged(int newSize)
    {
        PageSize = newSize;
        PageIndex = 0; // usually reset to first page
        await LoadPageAsync();
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

    private void SelectTrip(TripResponseViewModel trip)
    {
        SelectedTrip = trip;
        _ = OnTripSelected.InvokeAsync(trip);
    }

    private void CloseMap()
    {
        IsMapPopupVisible = false;
        MapStops.Clear();
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
}
