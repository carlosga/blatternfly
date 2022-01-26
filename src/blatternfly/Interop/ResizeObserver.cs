﻿using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blatternfly.Interop;

public sealed class ResizeObserver : IResizeObserver
{
    private readonly Lazy<Task<IJSObjectReference>>        _moduleTask;
    private readonly DotNetObjectReference<ResizeObserver> _dotNetObjRef;
    private readonly Subject<ResizeEvent>                  _resizeStream;

    public IObservable<ResizeEvent> OnResize  { get => _resizeStream.AsObservable(); }

    public ResizeObserver(IJSRuntime runtime)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => runtime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Blatternfly/observers/resize-observer.js").AsTask());
        _dotNetObjRef = DotNetObjectReference.Create(this);
        _resizeStream = new Subject<ResizeEvent>();
    }

    public async ValueTask DisposeAsync()
    {
        var module = await _moduleTask.Value;

        _resizeStream?.Dispose();
        _dotNetObjRef?.Dispose();
        await module.DisposeAsync();
    }

    [JSInvokable]
    public void OnContainerResize(ResizeEvent e)
    {
        _resizeStream.OnNext(e);
    }

    public async ValueTask ObserveAsync(ElementReference containerRefElement)
    {
        var module = await _moduleTask.Value;

        await module.InvokeVoidAsync("observe", containerRefElement, _dotNetObjRef);
    }

    public async ValueTask UnobserveAsync(ElementReference containerRefElement)
    {
        var module = await _moduleTask.Value;

        await module.InvokeVoidAsync("unobserve", containerRefElement);
    }
}