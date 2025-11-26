namespace Pharmatrack.Client.Services;

public class AppStateService
{
    private string _currentUser = "Guest";
    private bool _isSidebarCollapsed = false;
    
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

    public bool IsSidebarCollapsed
    {
        get => _isSidebarCollapsed;
        set
        {
            if (_isSidebarCollapsed != value)
            {
                _isSidebarCollapsed = value;
                NotifyStateChanged();
            }
        }
    }

    public void ToggleSidebar()
    {
        IsSidebarCollapsed = !IsSidebarCollapsed;
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
