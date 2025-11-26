namespace Pharmatrack.Client.SharedComponents;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

public partial class UserMenu : UiComponentBase
{
    [Parameter]
    public string UserName { get; set; } = "User";

    [Parameter]
    public string AvatarUrl { get; set; } = "images/user-avatar.png";

    [Parameter]
    public EventCallback OnEditProfile { get; set; }

    [Parameter]
    public EventCallback OnAccountSettings { get; set; }

    [Parameter]
    public EventCallback OnSignOut { get; set; }

    private bool isOpen = false;
    private ElementReference menuContainer;
    private DotNetObjectReference<UserMenu>? dotNetRef;

    protected override async Task OnAfterRenderCoreAsync(bool firstRender)
    {
        if (firstRender)
        {
            dotNetRef = DotNetObjectReference.Create(this);
            await JS.InvokeVoidAsync("eval", @"
                window.userMenuClickHandler = function(dotNetRef, element) {
                    document.addEventListener('click', function(e) {
                        if (!element.contains(e.target)) {
                            dotNetRef.invokeMethodAsync('CloseDropdown');
                        }
                    });
                    document.addEventListener('keydown', function(e) {
                        if (e.key === 'Escape') {
                            dotNetRef.invokeMethodAsync('CloseDropdown');
                        }
                    });
                };
            ");
            await JS.InvokeVoidAsync("userMenuClickHandler", dotNetRef, menuContainer);
        }
    }

    protected void ToggleDropdown()
    {
        isOpen = !isOpen;
    }

    [JSInvokable]
    public void CloseDropdown()
    {
        if (isOpen)
        {
            isOpen = false;
            StateHasChanged();
        }
    }

    protected async Task HandleEditProfile()
    {
        isOpen = false;
        await OnEditProfile.InvokeAsync();
    }

    protected async Task HandleAccountSettings()
    {
        isOpen = false;
        await OnAccountSettings.InvokeAsync();
    }

    protected async Task HandleSignOut()
    {
        isOpen = false;
        await OnSignOut.InvokeAsync();
    }

    protected override void DisposeCore()
    {
        dotNetRef?.Dispose();
    }
}
