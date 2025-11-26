// Deprecated: moved to Pharmatrack.ViewModels.Trip.TripViewModel
namespace Pharmatrack.ViewModels.Order;

[System.Obsolete("Use Pharmatrack.ViewModels.Trip.TripViewModel instead")]
public class OrderViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0;
    public int StockQuantity { get; set; } = 0;
    public string? Category { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}
