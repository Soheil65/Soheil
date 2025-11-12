using Pharmatrack.API.Data;
using Pharmatrack.API.Models;
using Pharmatrack.ViewModels.Products;
using Pharmatrack.ViewModels.Shared;

namespace Pharmatrack.API.Services;

public class ProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public BaseResponse<List<ProductViewModel>> GetAllProducts()
    {
        try
        {
            var products = _context.GetProducts();
            var viewModels = products.Select(p => MapToViewModel(p)).ToList();

            return new BaseResponse<List<ProductViewModel>>
            {
                Success = true,
                Data = viewModels,
                Message = "Products retrieved successfully"
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<ProductViewModel>>
            {
                Success = false,
                Message = "Failed to retrieve products",
                Errors = new List<string> { ex.Message }
            };
        }
    }

    public BaseResponse<ProductViewModel> GetProductById(int id)
    {
        try
        {
            var product = _context.GetProductById(id);
            if (product == null)
            {
                return new BaseResponse<ProductViewModel>
                {
                    Success = false,
                    Message = "Product not found"
                };
            }

            return new BaseResponse<ProductViewModel>
            {
                Success = true,
                Data = MapToViewModel(product),
                Message = "Product retrieved successfully"
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<ProductViewModel>
            {
                Success = false,
                Message = "Failed to retrieve product",
                Errors = new List<string> { ex.Message }
            };
        }
    }

    public BaseResponse<ProductViewModel> CreateProduct(ProductRequest request)
    {
        try
        {
            var dbProduct = new DbProduct
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                StockQuantity = request.StockQuantity,
                Category = request.Category
            };

            var created = _context.AddProduct(dbProduct);

            return new BaseResponse<ProductViewModel>
            {
                Success = true,
                Data = MapToViewModel(created),
                Message = "Product created successfully"
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<ProductViewModel>
            {
                Success = false,
                Message = "Failed to create product",
                Errors = new List<string> { ex.Message }
            };
        }
    }

    public BaseResponse<ProductViewModel> UpdateProduct(int id, ProductRequest request)
    {
        try
        {
            var dbProduct = new DbProduct
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                StockQuantity = request.StockQuantity,
                Category = request.Category
            };

            var updated = _context.UpdateProduct(id, dbProduct);
            if (updated == null)
            {
                return new BaseResponse<ProductViewModel>
                {
                    Success = false,
                    Message = "Product not found"
                };
            }

            return new BaseResponse<ProductViewModel>
            {
                Success = true,
                Data = MapToViewModel(updated),
                Message = "Product updated successfully"
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<ProductViewModel>
            {
                Success = false,
                Message = "Failed to update product",
                Errors = new List<string> { ex.Message }
            };
        }
    }

    public BaseResponse<bool> DeleteProduct(int id)
    {
        try
        {
            var deleted = _context.DeleteProduct(id);
            if (!deleted)
            {
                return new BaseResponse<bool>
                {
                    Success = false,
                    Message = "Product not found"
                };
            }

            return new BaseResponse<bool>
            {
                Success = true,
                Data = true,
                Message = "Product deleted successfully"
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>
            {
                Success = false,
                Message = "Failed to delete product",
                Errors = new List<string> { ex.Message }
            };
        }
    }

    private static ProductViewModel MapToViewModel(DbProduct product)
    {
        return new ProductViewModel
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            Category = product.Category,
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt
        };
    }
}
