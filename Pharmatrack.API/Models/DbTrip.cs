namespace Pharmatrack.API.Models;

public class DbTrip
{
    public int Id { get; set; }
    public string TripNumber { get; set; } = string.Empty;
    public Pharmatrack.ViewModels.Trip.TripStatus Status { get; set; } = Pharmatrack.ViewModels.Trip.TripStatus.Pending;
    public string? ServiceType { get; set; }
    public string? Description { get; set; }
    public DateTime DispatchTime { get; set; } = DateTime.UtcNow;
    public string? Dispatcher { get; set; }
    public string? Driver { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
