using Pharmatrack.Client.ServerConnector;
using Pharmatrack.Client.ServerConnector.Endpoints;

namespace Pharmatrack.Client.Services;

public class ApiClientService
{
    private readonly ApiConnector _apiConnector;
    public TripEndpoint Trip { get; }

    public ApiClientService(HttpClient httpClient)
    {
        _apiConnector = new ApiConnector(httpClient);
        Trip = new TripEndpoint(_apiConnector);
    }
}
