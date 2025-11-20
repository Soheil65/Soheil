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

    public async Task<BaseResponse<List<TripResponseViewModel>>?> GetAllTripsAsync()
    {
        return await _apiConnector.GetAsync<BaseResponse<List<TripResponseViewModel>>>(ApiRoutes.Trips.GetAll);
    }

    public async Task<BaseResponse<List<TripResponseViewModel>>?> GetTripsByFilterAsync(TripFilterRequestViewModel tripFilterRequestViewModel)
    {
        return await _apiConnector.PostAsync<TripFilterRequestViewModel, BaseResponse<List<TripResponseViewModel>>>(ApiRoutes.Trips.GetByFilters, tripFilterRequestViewModel);
    }

    public async Task<BaseResponse<TripResponseViewModel>?> GetTripByIdAsync(int id)
    {
        var endpoint = string.Format(ApiRoutes.Trips.GetById, id);
        return await _apiConnector.GetAsync<BaseResponse<TripResponseViewModel>>(endpoint);
    }

    public async Task<BaseResponse<TripResponseViewModel>?> CreateTripAsync(TripRequest request)
    {
        return await _apiConnector.PostAsync<TripRequest, BaseResponse<TripResponseViewModel>>(
            ApiRoutes.Trips.Create, request);
    }

    public async Task<BaseResponse<TripResponseViewModel>?> UpdateTripAsync(int id, TripRequest request)
    {
        var endpoint = string.Format(ApiRoutes.Trips.Update, id);
        return await _apiConnector.PutAsync<TripRequest, BaseResponse<TripResponseViewModel>>(endpoint, request);
    }

    public async Task<bool> DeleteTripAsync(int id)
    {
        var endpoint = string.Format(ApiRoutes.Trips.Delete, id);
        return await _apiConnector.DeleteAsync(endpoint);
    }
}
