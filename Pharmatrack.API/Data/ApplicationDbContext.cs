using Pharmatrack.API.Models;
using Pharmatrack.ViewModels.Trip;

namespace Pharmatrack.API.Data;

public class ApplicationDbContext
{
    private readonly List<DbTrip> _trips = new();
    private int _nextId = 1;

    public ApplicationDbContext()
    {
        // Seed some initial data
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-004", Status = TripStatus.Completed, ServiceType = "Delivery", Description = "Completed demo trip", DispatchTime = DateTime.UtcNow.AddHours(-1), Dispatcher = "Dispatch Team A", Driver = "Driver 1", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-005", Status = TripStatus.Pending, ServiceType = "Pickup", Description = "Scheduled morning pickup", DispatchTime = DateTime.UtcNow.AddHours(4), Dispatcher = "Dispatch Team C", Driver = "Driver 4", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-006", Status = TripStatus.Dispatched, ServiceType = "Delivery,Pickup", Description = "Rush order delivery/pickup", DispatchTime = DateTime.UtcNow.AddHours(5), Dispatcher = "Dispatch Team A", Driver = "Driver 5", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-007", Status = TripStatus.InProgress, ServiceType = "Delivery", Description = "Long haul delivery", DispatchTime = DateTime.UtcNow.AddHours(6), Dispatcher = "Dispatch Team B", Driver = "Driver 6", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-008", Status = TripStatus.Cancelled, ServiceType = "Pickup", Description = "Customer cancelled pickup", DispatchTime = DateTime.UtcNow.AddHours(7), Dispatcher = "Dispatch Team C", Driver = "Driver 7", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-009", Status = TripStatus.Pending, ServiceType = "Delivery", Description = "Evening delivery slot", DispatchTime = DateTime.UtcNow.AddHours(8), Dispatcher = "Dispatch Team A", Driver = "Driver 8", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-010", Status = TripStatus.Dispatched, ServiceType = "Pickup", Description = "Priority document pickup", DispatchTime = DateTime.UtcNow.AddHours(9), Dispatcher = "Dispatch Team B", Driver = "Driver 9", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-011", Status = TripStatus.Completed, ServiceType = "Delivery,Pickup", Description = "Completed dual service", DispatchTime = DateTime.UtcNow.AddHours(-2), Dispatcher = "Dispatch Team C", Driver = "Driver 10", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-012", Status = TripStatus.InProgress, ServiceType = "Delivery", Description = "Near completion delivery", DispatchTime = DateTime.UtcNow.AddHours(10), Dispatcher = "Dispatch Team A", Driver = "Driver 11", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-013", Status = TripStatus.Pending, ServiceType = "Pickup", Description = "Late night pickup request", DispatchTime = DateTime.UtcNow.AddHours(11), Dispatcher = "Dispatch Team B", Driver = "Driver 12", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-014", Status = TripStatus.Dispatched, ServiceType = "Delivery", Description = "Dispatched high value item", DispatchTime = DateTime.UtcNow.AddHours(12), Dispatcher = "Dispatch Team C", Driver = "Driver 13", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-015", Status = TripStatus.Pending, ServiceType = "Delivery,Pickup", Description = "Future scheduled job", DispatchTime = DateTime.UtcNow.AddDays(1), Dispatcher = "Dispatch Team A", Driver = "Driver 14", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-016", Status = TripStatus.Completed, ServiceType = "Pickup", Description = "Yesterday's completed pickup", DispatchTime = DateTime.UtcNow.AddDays(-1), Dispatcher = "Dispatch Team B", Driver = "Driver 15", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-017", Status = TripStatus.InProgress, ServiceType = "Delivery", Description = "Multi-stop route delivery", DispatchTime = DateTime.UtcNow.AddHours(13), Dispatcher = "Dispatch Team C", Driver = "Driver 16", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-018", Status = TripStatus.Dispatched, ServiceType = "Pickup", Description = "ASAP pickup needed", DispatchTime = DateTime.UtcNow.AddHours(0.5), Dispatcher = "Dispatch Team A", Driver = "Driver 17", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-019", Status = TripStatus.Pending, ServiceType = "Delivery", Description = "Standard non-urgent delivery", DispatchTime = DateTime.UtcNow.AddHours(14), Dispatcher = "Dispatch Team B", Driver = "Driver 18", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-020", Status = TripStatus.Cancelled, ServiceType = "Delivery", Description = "Cancelled before dispatch", DispatchTime = DateTime.UtcNow.AddHours(15), Dispatcher = "Dispatch Team C", Driver = "Driver 19", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-021", Status = TripStatus.InProgress, ServiceType = "Pickup", Description = "Driver en route for pickup", DispatchTime = DateTime.UtcNow.AddHours(16), Dispatcher = "Dispatch Team A", Driver = "Driver 20", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-022", Status = TripStatus.Completed, ServiceType = "Delivery,Pickup", Description = "Fast completed round trip", DispatchTime = DateTime.UtcNow.AddHours(-3), Dispatcher = "Dispatch Team B", Driver = "Driver 21", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-023", Status = TripStatus.Pending, ServiceType = "Delivery", Description = "Next week's delivery", DispatchTime = DateTime.UtcNow.AddDays(7), Dispatcher = "Dispatch Team C", Driver = "Driver 22", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-024", Status = TripStatus.Dispatched, ServiceType = "Pickup", Description = "Urgent medical sample pickup", DispatchTime = DateTime.UtcNow.AddHours(1), Dispatcher = "Dispatch Team A", Driver = "Driver 23", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-025", Status = TripStatus.InProgress, ServiceType = "Delivery", Description = "Driver performing final check", DispatchTime = DateTime.UtcNow.AddHours(17), Dispatcher = "Dispatch Team B", Driver = "Driver 24", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-026", Status = TripStatus.Pending, ServiceType = "Pickup", Description = "Standard business hours pickup", DispatchTime = DateTime.UtcNow.AddHours(18), Dispatcher = "Dispatch Team C", Driver = "Driver 25", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-027", Status = TripStatus.Dispatched, ServiceType = "Delivery", Description = "Early bird delivery run", DispatchTime = DateTime.UtcNow.AddHours(19), Dispatcher = "Dispatch Team A", Driver = "Driver 1", CreatedAt = DateTime.UtcNow });
        _trips.Add(new DbTrip { Id = _nextId++, TripNumber = "TR-028", Status = TripStatus.InProgress, ServiceType = "Delivery,Pickup", Description = "Complex multi-service route", DispatchTime = DateTime.UtcNow.AddHours(20), Dispatcher = "Dispatch Team B", Driver = "Driver 2", CreatedAt = DateTime.UtcNow });
    }
    public List<DbTrip> GetTrips() => _trips;

    public DbTrip? GetTripById(int id) => _trips.FirstOrDefault(p => p.Id == id);

    public DbTrip AddTrip(DbTrip trip)
    {
        trip.Id = _nextId++;
        trip.CreatedAt = DateTime.UtcNow;
        _trips.Add(trip);
        return trip;
    }

    public DbTrip? UpdateTrip(int id, DbTrip trip)
    {
        var existing = GetTripById(id);
        if (existing == null) return null;

        existing.TripNumber = trip.TripNumber;
        existing.Status = trip.Status;
        existing.ServiceType = trip.ServiceType;
        existing.Description = trip.Description;
        existing.DispatchTime = trip.DispatchTime;
        existing.Dispatcher = trip.Dispatcher;
        existing.Driver = trip.Driver;
        existing.UpdatedAt = DateTime.UtcNow;

        return existing;
    }

    public bool DeleteTrip(int id)
    {
        var trip = GetTripById(id);
        if (trip == null) return false;
        _trips.Remove(trip);
        return true;
    }
}
