using Microsoft.JSInterop;

namespace Blatternfly.Components;

internal sealed class FloatingInteropModule : IFloatingInteropModule
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public FloatingInteropModule(IJSRuntime runtime)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => runtime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Blatternfly/components/floating-ui.js").AsTask());
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }

    async ValueTask<FloatingPlacement<T>> IFloatingInteropModule.ComputePositionAsync<T>(
        string             referenceId,
        string             floatingId,
        FloatingOptions<T> options)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<FloatingPlacement<T>>(
            "computeFloatingPosition",
            referenceId,
            floatingId,
            options.Placement,
            options.Distance,
            options.EnableFlip,
            options.FallbackPlacements);
    }
}
