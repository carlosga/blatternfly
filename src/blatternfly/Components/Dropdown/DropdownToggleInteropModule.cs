using Microsoft.JSInterop;

namespace Blatternfly.Components;

internal sealed class DropdownToggleInteropModule : IDropdownToggleInteropModule
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public DropdownToggleInteropModule(IJSRuntime runtime)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => runtime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Blatternfly/components/dropdown-toggle.js").AsTask());
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }

    async ValueTask IDropdownToggleInteropModule.OnKeydown(DotNetObjectReference<Toggle> dotNetObjRef, ElementReference toggle)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("onKeyDown", dotNetObjRef, toggle);
    }
}
