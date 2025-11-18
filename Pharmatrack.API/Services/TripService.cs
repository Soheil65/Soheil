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

    public BaseResponse<List<TripViewModel>> GetAllTrips()
    {
        try
        {
            var products = _context.GetTrips();
            var viewModels = products.Select(p => MapToViewModel(p)).ToList();

            return new BaseResponse<List<TripViewModel>>
            {
                Success = true,
                Data = viewModels,
                Message = "Trips retrieved successfully"
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<TripViewModel>>
            {
                Success = false,
                Message = "Failed to retrieve trips",
                Errors = new List<string> { ex.Message }
            };
        }
    }

    public BaseResponse<TripViewModel> GetTripById(int id)
    {
        try
        {
            var product = _context.GetTripById(id);
            if (product == null)
            {
                return new BaseResponse<TripViewModel>
                {
                    Success = false,
                    Message = "Trip not found"
                };
            }

            return new BaseResponse<TripViewModel>
            {
                Success = true,
                Data = MapToViewModel(product),
                Message = "Trip retrieved successfully"
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<TripViewModel>
            {
                Success = false,
                Message = "Failed to retrieve trip",
                Errors = new List<string> { ex.Message }
            };
        }
    }

    public BaseResponse<TripViewModel> CreateTrip(TripRequest request)
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

            return new BaseResponse<TripViewModel>
            {
                Success = true,
                Data = MapToViewModel(created),
                Message = "Trip created successfully"
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<TripViewModel>
            {
                Success = false,
                Message = "Failed to create trip",
                Errors = new List<string> { ex.Message }
            };
        }
    }

    public BaseResponse<TripViewModel> UpdateTrip(int id, TripRequest request)
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
                return new BaseResponse<TripViewModel>
                {
                    Success = false,
                    Message = "Trip not found"
                };
            }

            return new BaseResponse<TripViewModel>
            {
                Success = true,
                Data = MapToViewModel(updated),
                Message = "Trip updated successfully"
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<TripViewModel>
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

    private static TripViewModel MapToViewModel(DbTrip product)
    {
        return new TripViewModel
        {
            Id = product.Id,
            TripNumber = product.TripNumber,
            Status = product.Status,
            ServiceType = product.ServiceType??string.Empty,
            Description = product.Description ?? string.Empty,
            DispatchTime = product.DispatchTime,
            Dispatcher = product.Dispatcher ?? string.Empty,
            Driver = product.Driver ?? string.Empty,
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt
        };
    }
}
