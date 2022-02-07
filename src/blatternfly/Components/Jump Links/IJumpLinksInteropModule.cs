using System;
using System.Threading.Tasks;

namespace Blatternfly.Components;

public interface IJumpLinksInteropModule : IAsyncDisposable
{
    IObservable<int> OnSetActiveIndex { get; }

    ValueTask ObserveAsync(
        ElementReference jumpLinksElement,
        string           scrollableSelector,
        string           offsetSelector);

    ValueTask UnobserveAsync(string scrollableSelector);

    ValueTask LockScrollAsync();
    ValueTask UnlockScrollAsync();
}
