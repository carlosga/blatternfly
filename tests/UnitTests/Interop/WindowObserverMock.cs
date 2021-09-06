using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Blatternfly.Events;
using Blatternfly.Interop;
using Microsoft.AspNetCore.Components.Web;

namespace Blatternfly.UnitTests.Interop
{
    public sealed class WindowObserverMock : IWindowObserver
    {
        private readonly Subject<MouseEvent>         _clickStream;
        private readonly Subject<KeyboardEventArgs>  _keydownStream;
        private readonly Subject<ResizeEvent>        _resizeStream;
        
        public bool                           CanUseDom { get => false;  }
        public IObservable<MouseEvent>        OnClick   { get => _clickStream.AsObservable(); }
        public IObservable<KeyboardEventArgs> OnKeydown { get => _keydownStream.AsObservable(); }
        public IObservable<ResizeEvent>       OnResize  {  get => _resizeStream.AsObservable(); }

        public WindowObserverMock()
        {
            _clickStream   = new Subject<MouseEvent>();
            _keydownStream = new Subject<KeyboardEventArgs>();
            _resizeStream  = new Subject<ResizeEvent>();
        }

        public ValueTask DisposeAsync()
        {
            _clickStream?.Dispose();
            _keydownStream?.Dispose();
            _resizeStream?.Dispose();
            
            return ValueTask.CompletedTask;
        }
        
        public Task ImportAsync()
        {
            return Task.CompletedTask;
        }

        public Task<Size<int>> GetWindowSizeAsync()
        {
            return Task.FromResult(new Size<int> { Width = 3840, Height = 2160 });
        }
    }
}
