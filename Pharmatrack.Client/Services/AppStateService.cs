namespace Pharmatrack.Client.Services;

public class AppStateService
{
    private string _currentUser = "Guest";
    
    public event Action? OnChange;

    public string CurrentUser
    {
        get => _currentUser;
        set
        {
            if (_currentUser != value)
            {
                _currentUser = value;
                NotifyStateChanged();
            }
        }
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
