namespace Blatternfly.Interop;

internal interface IWindowObserver : IAsyncDisposable
{
    IObservable<MouseEvent> OnClick { get; }
    IObservable<KeyboardEvent> OnKeydown { get; }
    IObservable<ResizeEvent> OnResize { get; }
    ValueTask ObserveAsync();
}
