using Pharmatrack.API.Data;
using Pharmatrack.API.Models;
using Pharmatrack.ViewModels.Trip;
using Pharmatrack.ViewModels.Shared;

namespace Pharmatrack.API.Services;

public class TripService
{
    private readonly ApplicationDbContext _context;

    public TripService(ApplicationDbContext context)
    {
        _context = context;
    }

    public BaseResponse<List<TripResponseViewModel>> GetAllTrips()
    {
        try
        {
            var products = _context.GetTrips();
            var viewModels = products.Select(p => MapToViewModel(p)).ToList();

            return new BaseResponse<List<TripResponseViewModel>>
            {
                Success = true,
                Data = viewModels,
                Message = "Trips retrieved successfully"
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<TripResponseViewModel>>
            {
                Success = false,
                Message = "Failed to retrieve trips",
                Errors = new List<string> { ex.Message }
            };
        }
    }


    public BaseResponse<List<TripResponseViewModel>> GetByFilters(TripFilterRequestViewModel tripFilterRequestViewModel)
    {
        try
        {
            var trips = _context.GetTrips();

            var filtered = trips.Where(t =>
                t.DispatchTime >= tripFilterRequestViewModel.StartDate &&
                t.DispatchTime <= tripFilterRequestViewModel.EndDate &&
                tripFilterRequestViewModel.Statuses.Contains(t.Status));

            int skip = (tripFilterRequestViewModel.PageNumber - 1) * tripFilterRequestViewModel.PageSize;

            var pagedTrips = filtered
                .Skip(skip)
                .Take(tripFilterRequestViewModel.PageSize)
                .ToList();

            var viewModels = pagedTrips.Select(MapToViewModel).ToList();

            return new BaseResponse<List<TripResponseViewModel>>
            {
                Success = true,
                Data = viewModels,
                Message = "Trips retrieved successfully"
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<TripResponseViewModel>>
            {
                Success = false,
                Message = "Failed to retrieve trips",
                Errors = new List<string> { ex.Message }
            };
        }
    }

    public BaseResponse<TripResponseViewModel> GetTripById(int id)
    {
        try
        {
            var product = _context.GetTripById(id);
            if (product == null)
            {
                return new BaseResponse<TripResponseViewModel>
                {
                    Success = false,
                    Message = "Trip not found"
                };
            }

            return new BaseResponse<TripResponseViewModel>
            {
                Success = true,
                Data = MapToViewModel(product),
                Message = "Trip retrieved successfully"
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<TripResponseViewModel>
            {
                Success = false,
                Message = "Failed to retrieve trip",
                Errors = new List<string> { ex.Message }
            };
        }
    }

    public BaseResponse<TripResponseViewModel> CreateTrip(TripRequest request)
    {
        try
        {
            var dbTrip = new DbTrip
            {
                TripNumber = request.TripNumber,
                Status = request.Status,
                ServiceType = request.ServiceTypes != null ? string.Join(',', request.ServiceTypes) : null,
                Description = request.Description,
                DispatchTime = request.DispatchTime,
                Dispatcher = request.Dispatcher,
                Driver = request.Driver
            };

            var created = _context.AddTrip(dbTrip);

            return new BaseResponse<TripResponseViewModel>
            {
                Success = true,
                Data = MapToViewModel(created),
                Message = "Trip created successfully"
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<TripResponseViewModel>
            {
                Success = false,
                Message = "Failed to create trip",
                Errors = new List<string> { ex.Message }
            };
        }
    }

    public BaseResponse<TripResponseViewModel> UpdateTrip(int id, TripRequest request)
    {
        try
        {
            var dbTrip = new DbTrip
            {
                TripNumber = request.TripNumber,
                Status = request.Status,
                ServiceType = request.ServiceTypes != null ? string.Join(',', request.ServiceTypes) : null,
                Description = request.Description,
                DispatchTime = request.DispatchTime,
                Dispatcher = request.Dispatcher,
                Driver = request.Driver
            };

            var updated = _context.UpdateTrip(id, dbTrip);
            if (updated == null)
            {
                return new BaseResponse<TripResponseViewModel>
                {
                    Success = false,
                    Message = "Trip not found"
                };
            }

            return new BaseResponse<TripResponseViewModel>
            {
                Success = true,
                Data = MapToViewModel(updated),
                Message = "Trip updated successfully"
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<TripResponseViewModel>
            {
                Success = false,
                Message = "Failed to update trip",
                Errors = new List<string> { ex.Message }
            };
        }
    }

    public BaseResponse<bool> DeleteTrip(int id)
    {
        try
        {
            var deleted = _context.DeleteTrip(id);
            if (!deleted)
            {
                return new BaseResponse<bool>
                {
                    Success = false,
                    Message = "Trip not found"
                };
            }

            return new BaseResponse<bool>
            {
                Success = true,
                Data = true,
                Message = "Trip deleted successfully"
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>
            {
                Success = false,
                Message = "Failed to delete trip",
                Errors = new List<string> { ex.Message }
            };
        }
    }

    private static TripResponseViewModel MapToViewModel(DbTrip product)
    {
        return new TripResponseViewModel
        {
            Id = product.Id,
            TripNumber = product.TripNumber,
            Status = product.Status,
            ServiceType = product.ServiceType ?? string.Empty,
            Description = product.Description ?? string.Empty,
            DispatchTime = product.DispatchTime,
            Dispatcher = product.Dispatcher ?? string.Empty,
            Driver = product.Driver ?? string.Empty,
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt
        };
    }
}
