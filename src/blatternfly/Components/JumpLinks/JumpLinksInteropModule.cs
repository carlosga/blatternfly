using System.Diagnostics.CodeAnalysis;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Microsoft.JSInterop;

namespace Blatternfly.Components;

internal sealed class JumpLinksInteropModule : IJumpLinksInteropModule
{
    private readonly Lazy<Task<IJSObjectReference>>                _moduleTask;
    private readonly DotNetObjectReference<JumpLinksInteropModule> _dotNetObjRef;
    private readonly Subject<int>                                  _scrollStream;

    public IObservable<int> OnSetActiveIndex { get => _scrollStream.AsObservable(); }

    [DynamicDependency(nameof(SetActiveIndex))]
    public JumpLinksInteropModule(IJSRuntime runtime)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => runtime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Blatternfly/components/jump-links.js").AsTask());
        _dotNetObjRef = DotNetObjectReference.Create(this);
        _scrollStream = new Subject<int>();
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        _scrollStream?.Dispose();
        _dotNetObjRef?.Dispose();

        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }

    [JSInvokable]
    public void SetActiveIndex(int activeIndex)
    {
        _scrollStream.OnNext(activeIndex);
    }

    async ValueTask IJumpLinksInteropModule.ObserveAsync(
        ElementReference jumpLinksElement,
        string           scrollableSelector,
        string           offsetSelector)
    {
        var module = await _moduleTask.Value;

        await module.InvokeVoidAsync(
            "observe",
            jumpLinksElement,
            scrollableSelector,
            offsetSelector,
            _dotNetObjRef);
    }

    async ValueTask IJumpLinksInteropModule.UnobserveAsync(string scrollableSelector)
    {
        var module = await _moduleTask.Value;

        await module.InvokeVoidAsync("unobserve", scrollableSelector);
    }

    async ValueTask IJumpLinksInteropModule.LockScrollAsync(string scrollableSelector)
    {
        var module = await _moduleTask.Value;

        await module.InvokeVoidAsync("lockScroll", scrollableSelector);
    }

    async ValueTask IJumpLinksInteropModule.UnlockScrollAsync(string scrollableSelector)
    {
        var module = await _moduleTask.Value;

        await module.InvokeVoidAsync("unlockScroll", scrollableSelector);
    }
}
