using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Blatternfly.UnitTests.Interop;

public sealed class WindowObserverMock : IWindowObserver
{
    private readonly Subject<MouseEvent>    _clickStream;
    private readonly Subject<KeyboardEvent> _keydownStream;
    private readonly Subject<ResizeEvent>   _resizeStream;

    public IObservable<MouseEvent>    OnClick   { get => _clickStream.AsObservable(); }
    public IObservable<KeyboardEvent> OnKeydown { get => _keydownStream.AsObservable(); }
    public IObservable<ResizeEvent>   OnResize  { get => _resizeStream.AsObservable(); }

    public WindowObserverMock()
    {
        _clickStream   = new Subject<MouseEvent>();
        _keydownStream = new Subject<KeyboardEvent>();
        _resizeStream  = new Subject<ResizeEvent>();
    }

    public ValueTask DisposeAsync()
    {
        _clickStream?.Dispose();
        _keydownStream?.Dispose();
        _resizeStream?.Dispose();

        return ValueTask.CompletedTask;
    }

    public ValueTask ObserveAsync()
    {
        return ValueTask.CompletedTask;
    }
}
