using System;
using System.Threading.Tasks;

namespace Blatternfly.Interop;

public interface IWindowObserver : IAsyncDisposable
{
    IObservable<MouseEvent> OnClick { get; }
    IObservable<KeyboardEvent> OnKeydown { get; }
    IObservable<ResizeEvent> OnResize { get; }
    Task ObserveAsync();
    Task<Size<int>> GetWindowSizeAsync();
}
