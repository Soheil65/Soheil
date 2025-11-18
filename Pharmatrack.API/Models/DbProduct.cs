namespace Pharmatrack.API.Models;

[System.Obsolete("DbProduct is deprecated. Use DbTrip instead.")]
public class DbProduct
{
    // Kept as a compatibility shim during the refactor. Prefer using DbTrip.
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string? Category { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
