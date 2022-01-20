using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blatternfly.Interop;

public sealed class DomUtils : IDomUtils
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public DomUtils(IJSRuntime runtime)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => runtime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Blatternfly/dom-utils/dom-utils.js").AsTask());
    }

    public async ValueTask DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }

    public async ValueTask SetBodyClass(string classlist)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setBodyClass", classlist);
    }

    public async ValueTask RemoveBodyClass(string classlist)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("removeBodyClass", classlist);
    }

    public async ValueTask<BoundingClientRect> GetBoundingClientRectAsync(ElementReference el)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<BoundingClientRect>("getBoundingClientRect", el);
    }

    public async ValueTask<Size<double>> GetOffsetSizeAsync(ElementReference el)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<Size<double>>("offsetSize", el);
    }

    public async ValueTask<Size<double>> GetScrollSizeAsync(ElementReference el)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<Size<double>>("scrollSize", el);
    }

    public async ValueTask ScrollLeftAsync(ElementReference el, double scrollWidth)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("scrollLeft", el, scrollWidth);
    }
}
