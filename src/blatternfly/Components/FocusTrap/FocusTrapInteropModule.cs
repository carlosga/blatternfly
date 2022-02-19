using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blatternfly.Components;

public sealed class FocusTrapInteropModule : IFocusTrapInteropModule
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public FocusTrapInteropModule(IJSRuntime runtime)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => runtime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Blatternfly/components/focus-trap-zone.js").AsTask());
    }

    public async ValueTask DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }

    public async Task<IJSObjectReference> CreateAsync(ElementReference reference, FocusTrapOptions options)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<IJSObjectReference>("create", reference, options);
    }

    public async Task ActivateAsync(IJSObjectReference focusTrap)
    {
        await focusTrap.InvokeVoidAsync("activate", focusTrap);
    }

    public async Task DeactivateAsync(IJSObjectReference focusTrap)
    {
        await focusTrap.InvokeVoidAsync("deactivate", focusTrap);
    }

    public async Task PauseAsync(IJSObjectReference focusTrap)
    {
        await focusTrap.InvokeVoidAsync("pause", focusTrap);
    }

    public async Task UnpauseAsync(IJSObjectReference focusTrap)
    {
        await focusTrap.InvokeVoidAsync("unpause", focusTrap);
    }
}
