namespace Pharmatrack.ViewModels.Trip;

public class TripRequest
{
    public string TripNumber { get; set; } = string.Empty;
    public TripStatus Status { get; set; } = TripStatus.Pending;
    public List<string> ServiceTypes { get; set; } = new();
    public string? Description { get; set; }
    public DateTime DispatchTime { get; set; } = DateTime.Now;
    public string? Dispatcher { get; set; }
    public string? Driver { get; set; }
}
