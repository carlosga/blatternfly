using System.Diagnostics.CodeAnalysis;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Microsoft.JSInterop;

namespace Blatternfly.Interop;

internal sealed class ResizeObserver : IResizeObserver
{
    private readonly Lazy<Task<IJSObjectReference>>        _moduleTask;
    private readonly DotNetObjectReference<ResizeObserver> _dotNetObjRef;
    private readonly Subject<ResizeEvent>                  _resizeStream;

    private IJSObjectReference _observerInstance;

    public IObservable<ResizeEvent> OnResize { get => _resizeStream.AsObservable(); }

    [DynamicDependency(nameof(OnContainerResize))]
    public ResizeObserver(IJSRuntime runtime)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => runtime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Blatternfly/observers/resize-observer.js").AsTask());
        _dotNetObjRef = DotNetObjectReference.Create(this);
        _resizeStream = new Subject<ResizeEvent>();
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        var module = await _moduleTask.Value;

        _resizeStream?.Dispose();
        _dotNetObjRef?.Dispose();
        await _observerInstance.InvokeVoidAsync("disconnect");
        await _observerInstance.DisposeAsync();
        await module.DisposeAsync();
    }

    [JSInvokable]
    public void OnContainerResize(ResizeEvent e)
    {
        _resizeStream.OnNext(e);
    }

    async ValueTask IResizeObserver.ObserveAsync(ElementReference containerRefElement)
    {
        var module = await _moduleTask.Value;

        _observerInstance = await module.InvokeAsync<IJSObjectReference>("observe", containerRefElement, _dotNetObjRef);
    }

    async ValueTask IResizeObserver.UnobserveAsync(ElementReference containerRefElement)
    {
        await _observerInstance.InvokeVoidAsync("unobserve", containerRefElement);
    }
}
