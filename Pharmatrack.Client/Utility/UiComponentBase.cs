namespace Pharmatrack.Client.Utility;

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

/// <summary>
/// Base class for all UI components providing common services, lifecycle hooks, and disposal patterns.
/// </summary>
public abstract class UiComponentBase : ComponentBase, IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Navigation manager for routing and URL operations.
    /// </summary>
    [Inject]
    protected NavigationManager Nav { get; set; } = default!;

    /// <summary>
    /// Logger factory for creating component-specific loggers.
    /// </summary>
    [Inject]
    protected ILoggerFactory LoggerFactory { get; set; } = default!;

    /// <summary>
    /// JavaScript runtime for interop operations.
    /// </summary>
    [Inject]
    protected IJSRuntime JS { get; set; } = default!;

    /// <summary>
    /// Component-specific logger.
    /// </summary>
    protected ILogger Logger => LoggerFactory.CreateLogger(GetType());

    /// <summary>
    /// Cancellation token source for async operations.
    /// </summary>
    protected CancellationTokenSource Cts { get; } = new();

    // ========================================
    // Lifecycle Hook: OnInitialized
    // ========================================

    /// <summary>
    /// Override to execute synchronous initialization logic.
    /// </summary>
    protected virtual void OnInitializedCore() { }

    /// <summary>
    /// Override to execute asynchronous initialization logic.
    /// </summary>
    protected virtual Task OnInitializedCoreAsync() => Task.CompletedTask;

    protected override void OnInitialized()
    {
        OnInitializedCore();
        base.OnInitialized();
    }

    protected override async Task OnInitializedAsync()
    {
        await OnInitializedCoreAsync();
        await base.OnInitializedAsync();
    }

    // ========================================
    // Lifecycle Hook: OnParametersSet
    // ========================================

    /// <summary>
    /// Override to execute synchronous logic when parameters are set.
    /// </summary>
    protected virtual void OnParametersSetCore() { }

    /// <summary>
    /// Override to execute asynchronous logic when parameters are set.
    /// </summary>
    protected virtual Task OnParametersSetCoreAsync() => Task.CompletedTask;

    protected override void OnParametersSet()
    {
        OnParametersSetCore();
        base.OnParametersSet();
    }

    protected override async Task OnParametersSetAsync()
    {
        await OnParametersSetCoreAsync();
        await base.OnParametersSetAsync();
    }

    // ========================================
    // Lifecycle Hook: OnAfterRender
    // ========================================

    /// <summary>
    /// Override to execute synchronous logic after rendering.
    /// </summary>
    /// <param name="firstRender">True if this is the first render.</param>
    protected virtual void OnAfterRenderCore(bool firstRender) { }

    /// <summary>
    /// Override to execute asynchronous logic after rendering.
    /// </summary>
    /// <param name="firstRender">True if this is the first render.</param>
    protected virtual Task OnAfterRenderCoreAsync(bool firstRender) => Task.CompletedTask;

    protected override void OnAfterRender(bool firstRender)
    {
        OnAfterRenderCore(firstRender);
        base.OnAfterRender(firstRender);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await OnAfterRenderCoreAsync(firstRender);
        await base.OnAfterRenderAsync(firstRender);
    }

    // ========================================
    // Lifecycle Hook: SetParametersAsync
    // ========================================

    public override Task SetParametersAsync(ParameterView parameters)
    {
        return base.SetParametersAsync(parameters);
    }

    // ========================================
    // Lifecycle Hook: ShouldRender
    // ========================================

    /// <summary>
    /// Override to control whether the component should render.
    /// </summary>
    /// <returns>True to render, false to skip rendering.</returns>
    protected virtual bool ShouldRenderCore() => true;

    protected override bool ShouldRender() => ShouldRenderCore();

    // ========================================
    // Disposal
    // ========================================

    /// <summary>
    /// Override to execute synchronous disposal logic.
    /// </summary>
    protected virtual void DisposeCore() { }

    /// <summary>
    /// Override to execute asynchronous disposal logic.
    /// </summary>
    protected virtual ValueTask DisposeCoreAsync() => ValueTask.CompletedTask;

    public void Dispose()
    {
        if (!Cts.IsCancellationRequested)
        {
            Cts.Cancel();
        }
        DisposeCore();
        Cts.Dispose();
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        if (!Cts.IsCancellationRequested)
        {
            Cts.Cancel();
        }
        await DisposeCoreAsync();
        Cts.Dispose();
        GC.SuppressFinalize(this);
    }
}
