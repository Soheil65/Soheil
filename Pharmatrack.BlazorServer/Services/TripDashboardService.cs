using Pharmatrack.BlazorServer.Models;
using Pharmatrack.ViewModels.Shared;
using Pharmatrack.ViewModels.Trip;

namespace Pharmatrack.BlazorServer.Services
{
    public class TripDashboardService
    {
        private TripFilterRequestViewModel _filter;
        private readonly ApiClientService _apiClient;

        // 🔹 Event that notifies subscribers when trips are updated
        public event Action? TripsChanged;

        // 🔹 Internal trips storage
        private List<TripResponseViewModel> _trips = new();
        public IReadOnlyList<TripResponseViewModel> Trips => _trips;

        public TripDashboardService(TripFilterRequestViewModel filter, ApiClientService apiClient)
        {
            _apiClient = apiClient;
            _filter = filter;
        }

        public async Task GetTripsByFilterAsync(DateTime startDate, DateTime endDate, List<TripStatus> statuses)
        {
            _filter.StartDate = startDate;
            _filter.EndDate = endDate;
            _filter.Statuses = statuses;
            await FetchTrips();
        }

        private async Task FetchTrips()
        {
            var response = await _apiClient.Trip.GetTripsByFilterAsync(_filter);
            if (response != null && response.Success && response.Data != null)
            {
                _trips = response.Data.ToList();
                TripsChanged?.Invoke();
            }
        }

        public async Task GetTripsByPaginationAsync(int pageNumber,int pageSize)
        {
            _filter.PageNumber = pageNumber;
            _filter.PageSize = pageSize;
           await FetchTrips();
        }

    }
}
