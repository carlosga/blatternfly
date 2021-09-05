using System;
using System.Threading.Tasks;
using Blatternfly.Events;
using Microsoft.AspNetCore.Components.Web;

namespace Blatternfly.Interop
{
    public interface IWindowObserver : IAsyncDisposable
    {
        bool CanUseDom { get; }
        IObservable<MouseEvent> OnClick { get; }
        IObservable<KeyboardEventArgs> OnKeydown { get; }
        IObservable<ResizeEvent> OnResize { get; }
        Task ImportAsync();
        Task<Size<int>> GetWindowSizeAsync();
    }
}
