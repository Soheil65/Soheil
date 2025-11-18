using Pharmatrack.ViewModels.Shared;
using Pharmatrack.Client.ServerConnector.Helpers;
using Pharmatrack.ViewModels.Trip;

namespace Pharmatrack.Client.ServerConnector.Endpoints;

public class TripEndpoint
{
    private readonly ApiConnector _apiConnector;

    public TripEndpoint(ApiConnector apiConnector)
    {
        _apiConnector = apiConnector;
    }

    public async Task<BaseResponse<List<TripViewModel>>?> GetAllTripsAsync()
    {
        return await _apiConnector.GetAsync<BaseResponse<List<TripViewModel>>>(ApiRoutes.Trips.GetAll);
    }

    public async Task<BaseResponse<TripViewModel>?> GetTripByIdAsync(int id)
    {
        var endpoint = string.Format(ApiRoutes.Trips.GetById, id);
        return await _apiConnector.GetAsync<BaseResponse<TripViewModel>>(endpoint);
    }

    public async Task<BaseResponse<TripViewModel>?> CreateTripAsync(TripRequest request)
    {
        return await _apiConnector.PostAsync<TripRequest, BaseResponse<TripViewModel>>(
            ApiRoutes.Trips.Create, request);
    }

    public async Task<BaseResponse<TripViewModel>?> UpdateTripAsync(int id, TripRequest request)
    {
        var endpoint = string.Format(ApiRoutes.Trips.Update, id);
        return await _apiConnector.PutAsync<TripRequest, BaseResponse<TripViewModel>>(endpoint, request);
    }

    public async Task<bool> DeleteTripAsync(int id)
    {
        var endpoint = string.Format(ApiRoutes.Trips.Delete, id);
        return await _apiConnector.DeleteAsync(endpoint);
    }
}
