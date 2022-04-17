using Microsoft.JSInterop;

namespace Blatternfly.Components;

internal sealed class TooltipInteropModule : ITooltipInteropModule
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;
    private readonly IFloatingInteropModule _floatingInterop;

    public TooltipInteropModule(IJSRuntime runtime, IFloatingInteropModule floatingInterop)
    {
        _floatingInterop = floatingInterop;
        _moduleTask      = new Lazy<Task<IJSObjectReference>>(() => runtime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Blatternfly/components/tooltip.js").AsTask());
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }

    async ValueTask<IJSObjectReference> ITooltipInteropModule.CreateAsync(DotNetObjectReference<Tooltip> dotNetObjRef, string reference)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<IJSObjectReference>("create", dotNetObjRef, reference);
    }

    async ValueTask<FloatingPlacement<T>> ITooltipInteropModule.ComputePositionAsync<T>(
        string             referenceId,
        string             floatingId,
        FloatingOptions<T> options)
    {
        return await _floatingInterop.ComputePositionAsync(referenceId, floatingId, options);
    }
}
