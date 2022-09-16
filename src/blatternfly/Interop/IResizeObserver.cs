namespace Blatternfly.Interop;

internal interface IResizeObserver : IAsyncDisposable
{
    IObservable<ResizeEvent> OnResize { get; }
    ValueTask ObserveAsync(ElementReference containerRefElement);
    ValueTask UnobserveAsync(ElementReference containerRefElement);
}
