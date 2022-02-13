using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Blatternfly.UnitTests.Interop;

public sealed class ResizeObserverMock : IResizeObserver
{
    private readonly Subject<ResizeEvent> _resizeStream;

    public IObservable<ResizeEvent> OnResize { get => _resizeStream.AsObservable(); }

    public ResizeObserverMock()
    {
        _resizeStream = new Subject<ResizeEvent>();
    }

    public ValueTask DisposeAsync()
    {
        _resizeStream?.Dispose();

        return ValueTask.CompletedTask;
    }

    public ValueTask ObserveAsync(ElementReference containerRefElement)
    {
        return ValueTask.CompletedTask;
    }

    public ValueTask UnobserveAsync(ElementReference containerRefElement)
    {
        return ValueTask.CompletedTask;
    }
}
