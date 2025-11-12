namespace Pharmatrack.Client.Pages.Products;

using Microsoft.AspNetCore.Components;
using Pharmatrack.ViewModels.Products;
using Pharmatrack.Client.Services;

public partial class Products : UiComponentBase
{
    [Inject]
    protected ApiClientService ApiClient { get; set; } = default!;

    private List<ProductViewModel>? products;
    private bool isLoading = true;
    private string? errorMessage;

    protected override async Task OnInitializedCoreAsync()
    {
        try
        {
            var response = await ApiClient.Products.GetAllProductsAsync();
            
            if (response != null && response.Success && response.Data != null)
            {
                products = response.Data;
            }
            else
            {
                errorMessage = response?.Message ?? "Failed to load products";
            }
        }
        catch (Exception ex)
        {
            errorMessage = $"Error: {ex.Message}";
            Logger.LogError(ex, "Failed to load products");
        }
        finally
        {
            isLoading = false;
        }
    }
}
