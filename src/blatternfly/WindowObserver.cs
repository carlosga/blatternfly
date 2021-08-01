using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace Blatternfly
{
    public sealed class WindowObserver : IDisposable
    {
        private IJSRuntime                            _jsRuntime;
        private DotNetObjectReference<WindowObserver> _dotNetObjRef;
        private Subject<KeyboardEventArgs>            _keydownStream;
        private Subject<Size>                         _resizeStream;
        
        public IObservable<KeyboardEventArgs> OnKeydown { get => _keydownStream.AsObservable(); }
        public IObservable<Size> OnResize { get => _resizeStream.AsObservable(); }
    
        public WindowObserver(IJSRuntime jsRuntime)
        {
            _jsRuntime     = jsRuntime;
            _dotNetObjRef  = DotNetObjectReference.Create(this);
            _keydownStream = new Subject<KeyboardEventArgs>();
            _resizeStream  = new Subject<Size>();
            
            _ = SubscribeToEvents();
        }

        public void Dispose()
        {
            _dotNetObjRef?.Dispose();
            _keydownStream?.Dispose();
            _resizeStream?.Dispose();
        }
        
        [JSInvokable]
        public void OnWindowKeydown(KeyboardEventArgs args)
        {
            _keydownStream.OnNext(args);
        }
        
        [JSInvokable]
        public void OnWindowResize(int w, int h)
        {
            _resizeStream.OnNext(new Size(w, h));
        }
        
        private async Task SubscribeToEvents()
        {
            await _jsRuntime.InvokeVoidAsync("Blatternfly.Window.onKeyDown", _dotNetObjRef);
            await _jsRuntime.InvokeVoidAsync("Blatternfly.Window.onResize", _dotNetObjRef);
        }
    }
}
