namespace MyBlazorApp.Client.Services;

public interface IAppStateService
{
    event Action? OnChange;
    bool IsLoading { get; set; }
    string? ErrorMessage { get; set; }
    void NotifyStateChanged();
}
