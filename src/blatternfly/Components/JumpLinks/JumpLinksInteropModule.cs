using System.Reactive.Linq;
using System.Reactive.Subjects;
using Microsoft.JSInterop;

namespace Blatternfly.Components;

public sealed class JumpLinksInteropModule : IJumpLinksInteropModule
{
    private readonly Lazy<Task<IJSObjectReference>>                _moduleTask;
    private readonly DotNetObjectReference<JumpLinksInteropModule> _dotNetObjRef;
    private readonly Subject<int>                                  _scrollStream;

    public IObservable<int> OnSetActiveIndex { get => _scrollStream.AsObservable(); }

    public JumpLinksInteropModule(IJSRuntime runtime)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => runtime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Blatternfly/components/jump-links.js").AsTask());
        _dotNetObjRef = DotNetObjectReference.Create(this);
        _scrollStream = new Subject<int>();
    }

    public async ValueTask DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            _scrollStream?.Dispose();
            _dotNetObjRef?.Dispose();
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }

    [JSInvokable]
    public void SetActiveIndex(int activeIndex)
    {
        _scrollStream.OnNext(activeIndex);
    }

    public async ValueTask ObserveAsync(
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

    public async ValueTask UnobserveAsync(string scrollableSelector)
    {
        var module = await _moduleTask.Value;

        await module.InvokeVoidAsync("unobserve", scrollableSelector);
    }

    public async ValueTask LockScrollAsync(string scrollableSelector)
    {
        var module = await _moduleTask.Value;

        await module.InvokeVoidAsync("lockScroll", scrollableSelector);
    }

    public async ValueTask UnlockScrollAsync(string scrollableSelector)
    {
        var module = await _moduleTask.Value;

        await module.InvokeVoidAsync("unlockScroll", scrollableSelector);
    }
}
