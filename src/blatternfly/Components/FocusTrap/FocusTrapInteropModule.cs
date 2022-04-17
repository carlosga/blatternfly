using Microsoft.JSInterop;

namespace Blatternfly.Components;

internal sealed class FocusTrapInteropModule : IFocusTrapInteropModule
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public FocusTrapInteropModule(IJSRuntime runtime)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => runtime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Blatternfly/components/focus-trap-zone.js").AsTask());
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }

    async Task<IJSObjectReference> IFocusTrapInteropModule.CreateAsync(ElementReference reference, FocusTrapOptions options)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<IJSObjectReference>("create", reference, options);
    }

    async Task IFocusTrapInteropModule.ActivateAsync(IJSObjectReference focusTrap)
    {
        await focusTrap.InvokeVoidAsync("activate", focusTrap);
    }

    async Task IFocusTrapInteropModule.DeactivateAsync(IJSObjectReference focusTrap)
    {
        await focusTrap.InvokeVoidAsync("deactivate", focusTrap);
    }

    async Task IFocusTrapInteropModule.PauseAsync(IJSObjectReference focusTrap)
    {
        await focusTrap.InvokeVoidAsync("pause", focusTrap);
    }

    async Task IFocusTrapInteropModule.UnpauseAsync(IJSObjectReference focusTrap)
    {
        await focusTrap.InvokeVoidAsync("unpause", focusTrap);
    }
}
