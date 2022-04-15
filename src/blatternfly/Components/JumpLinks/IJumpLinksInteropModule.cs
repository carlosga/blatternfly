namespace Blatternfly.Components;

public interface IJumpLinksInteropModule : IAsyncDisposable
{
    IObservable<int> OnSetActiveIndex { get; }

    ValueTask ObserveAsync(
        ElementReference jumpLinksElement,
        string           scrollableSelector,
        string           offsetSelector);

    ValueTask UnobserveAsync(string scrollableSelector);

    ValueTask LockScrollAsync(string scrollableSelector);
    ValueTask UnlockScrollAsync(string scrollableSelector);
}
