using System;
using System.Threading.Tasks;

namespace Blatternfly.Interop;

public interface IResizeObserver : IAsyncDisposable
{
    IObservable<ResizeEvent> OnResize { get; }
    Task ObserveAsync(ElementReference containerRefElement);
}
