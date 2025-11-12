namespace MyBlazorApp.Client.Services;

public class AppStateService : IAppStateService
{
    private bool _isLoading;
    private string? _errorMessage;

    public event Action? OnChange;

    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            if (_isLoading != value)
            {
                _isLoading = value;
                NotifyStateChanged();
            }
        }
    }

    public string? ErrorMessage
    {
        get => _errorMessage;
        set
        {
            if (_errorMessage != value)
            {
                _errorMessage = value;
                NotifyStateChanged();
            }
        }
    }

    public void NotifyStateChanged() => OnChange?.Invoke();
}
