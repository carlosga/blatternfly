using System;
using System.Threading.Tasks;
using Blatternfly.Events;
using Microsoft.AspNetCore.Components.Web;

namespace Blatternfly.Interop;

public interface IWindowObserver : IAsyncDisposable
{
    bool CanUseDom { get; }
    IObservable<MouseEvent> OnClick { get; }
    IObservable<KeyboardEvent> OnKeydown { get; }
    IObservable<ResizeEvent> OnResize { get; }
    Task BindAsync();
    Task<Size<int>> GetWindowSizeAsync();
}
