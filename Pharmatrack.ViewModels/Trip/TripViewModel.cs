namespace Pharmatrack.ViewModels.Trip;

public enum TripStatus
{
    Pending,
    Dispatched,
    InProgress,
    Completed,
    Cancelled
}

public class TripViewModel
{
    public int Id { get; set; }
    public string TripNumber { get; set; } = string.Empty;
    public TripStatus Status { get; set; } = TripStatus.Pending;
    public string ServiceType { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DispatchTime { get; set; } = DateTime.Now;
    public string Dispatcher { get; set; } = string.Empty;
    public string Driver { get; set; } = string.Empty; 
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}
