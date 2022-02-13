using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace Blatternfly.UnitTests.Interop;

public sealed class JumpLinksInteropMockModule : IJumpLinksInteropModule
{
    private readonly Subject<int> _scrollStream;

    public IObservable<int> OnSetActiveIndex { get => _scrollStream.AsObservable(); }

    public JumpLinksInteropMockModule()
    {
        _scrollStream = new Subject<int>();
    }

    public ValueTask DisposeAsync()
    {
        _scrollStream?.Dispose();

        return ValueTask.CompletedTask;
    }

    public ValueTask ObserveAsync(
        ElementReference jumpLinksElement,
        string           scrollableSelector,
        string           offsetSelector)
    {
        return ValueTask.CompletedTask;
    }

    public ValueTask UnobserveAsync(string scrollableSelector)
    {
        return ValueTask.CompletedTask;
    }

    public ValueTask LockScrollAsync(string scrollableSelector)
    {
        return ValueTask.CompletedTask;
    }

    public ValueTask UnlockScrollAsync(string scrollableSelector)
    {
        return ValueTask.CompletedTask;
    }
}
