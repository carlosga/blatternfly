using System;
using System.Threading.Tasks;
using Blatternfly.Events;
using Microsoft.AspNetCore.Components.Web;

namespace Blatternfly.Observers
{
    public interface IWindowObserver
    {
        bool CanUseDom { get; }
        IObservable<MouseEvent> OnClick { get; }
        IObservable<KeyboardEventArgs> OnKeydown { get; }
        IObservable<ResizeEvent> OnResize { get; }
        Task OnbserveAsync();
        Task<Size<int>> GetWindowSizeAsync();
    }
}
