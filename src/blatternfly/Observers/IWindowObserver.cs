using System;
using System.Threading.Tasks;
using Blatternfly.Events;
using Microsoft.AspNetCore.Components.Web;

namespace Blatternfly.Observers
{
    public interface IWindowObserver
    {
        IObservable<MouseEvent> OnClick { get; }
        IObservable<KeyboardEventArgs> OnKeydown { get; }
        IObservable<ResizeEvent> OnResize { get; }
        Task OnbserveAsync();
    }
}
