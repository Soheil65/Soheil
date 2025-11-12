using Pharmatrack.Client.ServerConnector;
using Pharmatrack.Client.ServerConnector.Endpoints;

namespace Pharmatrack.Client.Services;

public class ApiClientService
{
    private readonly ApiConnector _apiConnector;
    public ProductEndpoint Products { get; }

    public ApiClientService(HttpClient httpClient)
    {
        _apiConnector = new ApiConnector(httpClient);
        Products = new ProductEndpoint(_apiConnector);
    }
}
