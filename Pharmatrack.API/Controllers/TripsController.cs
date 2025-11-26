using Microsoft.AspNetCore.Mvc;
using Pharmatrack.API.Services;
using Pharmatrack.ViewModels.Trip;

namespace Pharmatrack.API.Controllers;

/// <summary>
/// API controller for managing trips (previously orders).
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class TripsController : ControllerBase
{
    private readonly TripService _tripService;

    public TripsController(TripService tripService)
    {
        _tripService = tripService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var response = _tripService.GetAllTrips();
        if (!response.Success)
            return BadRequest(response);
        return Ok(response);
    }


    [HttpPost("GetByFilters")]
    public IActionResult GetByFilters([FromBody] TripFilterRequestViewModel tripFilterRequestViewModel)
    {
        var response = _tripService.GetByFilters(tripFilterRequestViewModel);
        if (!response.Success)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var response = _tripService.GetTripById(id);
        if (!response.Success)
            return NotFound(response);
        return Ok(response);
    }

    [HttpPost]
    public IActionResult Create([FromBody] TripRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = _tripService.CreateTrip(request);
        if (!response.Success)
            return BadRequest(response);

        return CreatedAtAction(nameof(GetById), new { id = response.Data?.Id }, response);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] TripRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = _tripService.UpdateTrip(id, request);
        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var response = _tripService.DeleteTrip(id);
        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }
}
