using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blatternfly.Components;

public sealed class PopperInteropModule : IPopperInteropModule
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public PopperInteropModule(IJSRuntime runtime)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => runtime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Blatternfly/components/floating-ui.js").AsTask());
    }

    public async ValueTask DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }

    public async Task ComputePositionAsync(
        string        referenceId,
        string        floatingId,
        PopperOptions options = null)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("computeFloatingPosition", referenceId, floatingId, options);
    }
}
