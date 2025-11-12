using Pharmatrack.ViewModels.Products;
using Pharmatrack.ViewModels.Shared;
using Pharmatrack.Client.ServerConnector.Helpers;

namespace Pharmatrack.Client.ServerConnector.Endpoints;

public class ProductEndpoint
{
    private readonly ApiConnector _apiConnector;

    public ProductEndpoint(ApiConnector apiConnector)
    {
        _apiConnector = apiConnector;
    }

    public async Task<BaseResponse<List<ProductViewModel>>?> GetAllProductsAsync()
    {
        return await _apiConnector.GetAsync<BaseResponse<List<ProductViewModel>>>(ApiRoutes.Products.GetAll);
    }

    public async Task<BaseResponse<ProductViewModel>?> GetProductByIdAsync(int id)
    {
        var endpoint = string.Format(ApiRoutes.Products.GetById, id);
        return await _apiConnector.GetAsync<BaseResponse<ProductViewModel>>(endpoint);
    }

    public async Task<BaseResponse<ProductViewModel>?> CreateProductAsync(ProductRequest request)
    {
        return await _apiConnector.PostAsync<ProductRequest, BaseResponse<ProductViewModel>>(
            ApiRoutes.Products.Create, request);
    }

    public async Task<BaseResponse<ProductViewModel>?> UpdateProductAsync(int id, ProductRequest request)
    {
        var endpoint = string.Format(ApiRoutes.Products.Update, id);
        return await _apiConnector.PutAsync<ProductRequest, BaseResponse<ProductViewModel>>(endpoint, request);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var endpoint = string.Format(ApiRoutes.Products.Delete, id);
        return await _apiConnector.DeleteAsync(endpoint);
    }
}
