// Deprecated: moved to Pharmatrack.ViewModels.Trip.TripRequest
namespace Pharmatrack.ViewModels.Order;

[System.Obsolete("Use Pharmatrack.ViewModels.Trip.TripRequest instead")]
public class OrderRequest
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string? Category { get; set; }
}
