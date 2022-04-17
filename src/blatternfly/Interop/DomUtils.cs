using Microsoft.JSInterop;

namespace Blatternfly.Interop;

internal sealed class DomUtils : IDomUtils
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public DomUtils(IJSRuntime runtime)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => runtime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Blatternfly/dom-utils/dom-utils.js").AsTask());
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }

    async ValueTask IDomUtils.SetBodyClass(string classlist)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setBodyClass", classlist);
    }

    async ValueTask IDomUtils.RemoveBodyClass(string classlist)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("removeBodyClass", classlist);
    }

    async ValueTask<Size<int>> IDomUtils.GetWindowSizeAsync()
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<Size<int>>("getWindowSize");
    }

    async ValueTask<BoundingClientRect> IDomUtils.GetBoundingClientRectAsync(ElementReference el)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<BoundingClientRect>("getBoundingClientRect", el);
    }

    async ValueTask<Size<int>> IDomUtils.GetClientSizeAsync(ElementReference el)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<Size<int>>("clientSize", el);
    }

    async ValueTask<Size<double>> IDomUtils.GetOffsetSizeAsync(ElementReference el)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<Size<double>>("offsetSize", el);
    }

    async ValueTask<Size<double>> IDomUtils.GetScrollSizeAsync(ElementReference el)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<Size<double>>("scrollSize", el);
    }

    async ValueTask IDomUtils.ScrollLeftAsync(ElementReference el, double scrollWidth)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("scrollLeft", el, scrollWidth);
    }

    async ValueTask IDomUtils.ScrollIntoViewAsync(string elementId)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("scrollIntoView", elementId);
    }

    async ValueTask<bool> IDomUtils.HasTruncatedHeight(ElementReference el)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<bool>("hasTruncatedHeight", el);
    }

    async ValueTask<bool> IDomUtils.HasTruncatedWidth(ElementReference el)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<bool>("hasTruncatedWidth", el);
    }
}
