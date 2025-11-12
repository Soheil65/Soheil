using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlazorApp.Server.Models;
using MyBlazorApp.ViewModels.Requests;
using MyBlazorApp.ViewModels.Responses;
using MyBlazorApp.ViewModels.ViewModels;

namespace MyBlazorApp.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<UserController> _logger;

    public UserController(UserManager<ApplicationUser> userManager, ILogger<UserController> logger)
    {
        _userManager = userManager;
        _logger = logger;
    }

    [HttpGet("profile")]
    public async Task<ActionResult<ApiResponse<UserProfileViewModel>>> GetProfile()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized(ApiResponse<UserProfileViewModel>.FailureResponse("User not authenticated"));
        }

        var user = await _userManager.FindByIdAsync(userId);
        
        if (user == null)
        {
            return NotFound(ApiResponse<UserProfileViewModel>.FailureResponse("User not found"));
        }

        var profile = new UserProfileViewModel
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName
        };

        return Ok(ApiResponse<UserProfileViewModel>.SuccessResponse(profile));
    }

    [HttpPut("profile")]
    public async Task<ActionResult<ApiResponse<UserProfileViewModel>>> UpdateProfile([FromBody] UpdateProfileRequest request)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized(ApiResponse<UserProfileViewModel>.FailureResponse("User not authenticated"));
        }

        var user = await _userManager.FindByIdAsync(userId);
        
        if (user == null)
        {
            return NotFound(ApiResponse<UserProfileViewModel>.FailureResponse("User not found"));
        }

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;

        var result = await _userManager.UpdateAsync(user);
        
        if (!result.Succeeded)
        {
            return BadRequest(ApiResponse<UserProfileViewModel>.FailureResponse(
                "Failed to update profile",
                result.Errors.Select(e => e.Description).ToList()
            ));
        }

        var profile = new UserProfileViewModel
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName
        };

        return Ok(ApiResponse<UserProfileViewModel>.SuccessResponse(profile));
    }
}
