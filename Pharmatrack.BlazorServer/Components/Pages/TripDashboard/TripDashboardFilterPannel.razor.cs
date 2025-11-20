using Microsoft.AspNetCore.Components;
using Pharmatrack.API.Services;
using Pharmatrack.BlazorServer.Models;
using Pharmatrack.BlazorServer.Services;
using Pharmatrack.BlazorServer.Utility;
using Pharmatrack.ViewModels.Trip;

namespace Pharmatrack.BlazorServer.Components.Pages.TripDashboard;
public partial class TripDashboardFilterPannel : UiComponentBase
{
    [Inject]
    TripDashboardService tripService { get; set; }

    [Parameter]
    public string Class { get; set; }

    IEnumerable<Item> Data { get; set; } = new List<Item> { new Item { Id = "2", Name = "InProgress" }, new Item { Id = "3", Name = "Completed" }, new Item { Id = "0", Name = "Pending" }, new Item { Id = "1", Name = "Dispatched" }, new Item { Id = "4", Name = "Cancelled" } };
    IEnumerable<Item> Values { get; set; } = new List<Item> { new Item { Id = "2", Name = "InProgress" }, new Item { Id = "3", Name = "Completed" }, new Item { Id = "0", Name = "Pending" }, new Item { Id = "1", Name = "Dispatched" }, new Item { Id = "4", Name = "Cancelled" } };

    DateTime DateTimeStart { get; set; } = DateTime.Today;
    DateTime DateTimeEnd { get; set; } = DateTime.Today.AddDays(7);

    private async void onFilterChanged()
    {
        await FetchTripsData();
    }

    private async Task FetchTripsData()
    {
        var selectedStatuses = Values.Select(v => Enum.Parse<TripStatus>(v.Name)).ToList();
        await tripService.GetTripsByFilterAsync(DateTimeStart, DateTimeEnd, selectedStatuses);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender)
            return;

        await FetchTripsData();

        StateHasChanged();
    }


}


