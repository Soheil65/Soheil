using Pharmatrack.API.Models;

namespace Pharmatrack.API.Data;

public class ApplicationDbContext
{
    private readonly List<DbProduct> _products = new();
    private int _nextId = 1;

    public ApplicationDbContext()
    {
        // Seed some initial data
        _products.Add(new DbProduct
        {
            Id = _nextId++,
            Name = "Aspirin",
            Description = "Pain reliever and fever reducer",
            Price = 9.99m,
            StockQuantity = 100,
            Category = "Pain Relief",
            CreatedAt = DateTime.UtcNow
        });
        _products.Add(new DbProduct
        {
            Id = _nextId++,
            Name = "Ibuprofen",
            Description = "Anti-inflammatory medication",
            Price = 12.99m,
            StockQuantity = 75,
            Category = "Pain Relief",
            CreatedAt = DateTime.UtcNow
        });
        _products.Add(new DbProduct
        {
            Id = _nextId++,
            Name = "Vitamin C",
            Description = "Immune system support",
            Price = 15.99m,
            StockQuantity = 150,
            Category = "Vitamins",
            CreatedAt = DateTime.UtcNow
        });
    }

    public List<DbProduct> GetProducts() => _products;

    public DbProduct? GetProductById(int id) => _products.FirstOrDefault(p => p.Id == id);

    public DbProduct AddProduct(DbProduct product)
    {
        product.Id = _nextId++;
        product.CreatedAt = DateTime.UtcNow;
        _products.Add(product);
        return product;
    }

    public DbProduct? UpdateProduct(int id, DbProduct product)
    {
        var existing = GetProductById(id);
        if (existing == null) return null;

        existing.Name = product.Name;
        existing.Description = product.Description;
        existing.Price = product.Price;
        existing.StockQuantity = product.StockQuantity;
        existing.Category = product.Category;
        existing.UpdatedAt = DateTime.UtcNow;

        return existing;
    }

    public bool DeleteProduct(int id)
    {
        var product = GetProductById(id);
        if (product == null) return false;
        _products.Remove(product);
        return true;
    }
}
