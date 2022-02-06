using System;
using System.Threading.Tasks;
using Blatternfly.Interop;

namespace Blatternfly.Components;

public interface IJumpLinksInteropModule : IAsyncDisposable
{
    IObservable<int> OnScroll { get; }

    ValueTask ObserveAsync(ElementReference jumpLinksElement, string scrollableSelector);

    ValueTask UnobserveAsync(string scrollableSelector);
}
