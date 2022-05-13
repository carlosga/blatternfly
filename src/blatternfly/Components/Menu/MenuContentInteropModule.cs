using Microsoft.JSInterop;

namespace Blatternfly.Components;

internal sealed class MenuContentInteropModule : IMenuContentInteropModule
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public MenuContentInteropModule(IJSRuntime runtime)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => runtime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Blatternfly/components/menu-content.js").AsTask());
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }

    async ValueTask<double?> IMenuContentInteropModule.RefCallback(DotNetObjectReference<MenuContent> dotNetObjRef, ElementReference reference)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<double>("refCallback", dotNetObjRef, reference);
    }
}
