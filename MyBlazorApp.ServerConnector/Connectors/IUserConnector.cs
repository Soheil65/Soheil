using MyBlazorApp.ViewModels.Requests;
using MyBlazorApp.ViewModels.Responses;
using MyBlazorApp.ViewModels.ViewModels;

namespace MyBlazorApp.ServerConnector.Connectors;

public interface IUserConnector
{
    Task<ApiResponse<UserProfileViewModel>> GetProfileAsync();
    Task<ApiResponse<UserProfileViewModel>> UpdateProfileAsync(UpdateProfileRequest request);
}
