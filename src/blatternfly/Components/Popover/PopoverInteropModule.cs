using Microsoft.JSInterop;

namespace Blatternfly.Components;

internal sealed class PopoverInteropModule : IPopoverInteropModule
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;
    private readonly IFloatingInteropModule _floatingInterop;

    public PopoverInteropModule(IJSRuntime runtime, IFloatingInteropModule floatingInterop)
    {
        _floatingInterop = floatingInterop;
        _moduleTask      = new Lazy<Task<IJSObjectReference>>(() => runtime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Blatternfly/components/popover.js").AsTask());
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }

    async ValueTask<IJSObjectReference> IPopoverInteropModule.CreateAsync(DotNetObjectReference<Popover> dotNetObjRef, string reference)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<IJSObjectReference>("create", dotNetObjRef, reference);
    }

    async ValueTask<FloatingPlacement<T>> IPopoverInteropModule.ComputePositionAsync<T>(
        string             referenceId,
        string             floatingId,
        FloatingOptions<T> options)
    {
        return await _floatingInterop.ComputePositionAsync(referenceId, floatingId, options);
    }
}
