﻿using System.Diagnostics.CodeAnalysis;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Microsoft.JSInterop;

namespace Blatternfly.Interop;

internal sealed class WindowObserver : IWindowObserver
{
    private readonly Lazy<Task<IJSObjectReference>>        _moduleTask;
    private readonly DotNetObjectReference<WindowObserver> _dotNetObjRef;
    private readonly Subject<MouseEvent>                   _clickStream;
    private readonly Subject<KeyboardEvent>                _keydownStream;
    private readonly Subject<ResizeEvent>                  _resizeStream;

    public IObservable<MouseEvent>    OnClick   { get => _clickStream.AsObservable(); }
    public IObservable<KeyboardEvent> OnKeydown { get => _keydownStream.AsObservable(); }
    public IObservable<ResizeEvent>   OnResize  { get => _resizeStream.AsObservable(); }

    [DynamicDependency(nameof(OnWindowClick))]
    [DynamicDependency(nameof(OnWindowKeydown))]
    [DynamicDependency(nameof(OnWindowResize))]
    public WindowObserver(IJSRuntime runtime)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => runtime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Blatternfly/observers/window-observer.js").AsTask());
        _dotNetObjRef  = DotNetObjectReference.Create(this);
        _clickStream   = new Subject<MouseEvent>();
        _keydownStream = new Subject<KeyboardEvent>();
        _resizeStream  = new Subject<ResizeEvent>();
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
        _dotNetObjRef?.Dispose();
        _clickStream?.Dispose();
        _keydownStream?.Dispose();
        _resizeStream?.Dispose();
    }

    [JSInvokable]
    public void OnWindowClick(MouseEvent e)
    {
        _clickStream.OnNext(e);
    }

    [JSInvokable]
    public void OnWindowKeydown(KeyboardEvent e)
    {
        _keydownStream.OnNext(e);
    }

    [JSInvokable]
    public void OnWindowResize(ResizeEvent e)
    {
        _resizeStream.OnNext(e);
    }

    async ValueTask IWindowObserver.ObserveAsync()
    {
        var module = await _moduleTask.Value;

        await module.InvokeVoidAsync("onClick"  , _dotNetObjRef);
        await module.InvokeVoidAsync("onKeyDown", _dotNetObjRef);
        await module.InvokeVoidAsync("onResize" , _dotNetObjRef);
    }
}
