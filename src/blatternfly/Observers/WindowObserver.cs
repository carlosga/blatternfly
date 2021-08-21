using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Blatternfly.Events;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace Blatternfly.Observers
{
    public sealed class WindowObserver : IWindowObserver, IDisposable
    {
        private readonly IJSRuntime                            _jsRuntime;
        private readonly DotNetObjectReference<WindowObserver> _dotNetObjRef;
        private readonly Subject<MouseEvent>                   _clickStream;
        private readonly Subject<KeyboardEventArgs>            _keydownStream;
        private readonly Subject<ResizeEvent>                  _resizeStream;
        
        private bool _canUseDom;

        public bool                           CanUseDom { get => _canUseDom; }
        public IObservable<MouseEvent>        OnClick   { get => _clickStream.AsObservable(); }
        public IObservable<KeyboardEventArgs> OnKeydown { get => _keydownStream.AsObservable(); }
        public IObservable<ResizeEvent>       OnResize  { get => _resizeStream.AsObservable(); }
    
        public WindowObserver(IJSRuntime jsRuntime)
        {
            _jsRuntime     = jsRuntime;
            _dotNetObjRef  = DotNetObjectReference.Create(this);
            _clickStream   = new Subject<MouseEvent>();
            _keydownStream = new Subject<KeyboardEventArgs>();
            _resizeStream  = new Subject<ResizeEvent>();
        }

        public void Dispose()
        {
            _dotNetObjRef?.Dispose();
            _clickStream?.Dispose();
            _keydownStream?.Dispose();
            _resizeStream?.Dispose();
        }

        [JSInvokable]
        public void OnWindowClick(MouseEvent e)
        {
            _clickStream.OnNext(e);
        }
        
        [JSInvokable]
        public void OnWindowKeydown(KeyboardEventArgs args)
        {
            _keydownStream.OnNext(args);
        }
        
        [JSInvokable]
        public void OnWindowResize(ResizeEvent e)
        {
            _resizeStream.OnNext(e);
        }
        
        public async Task OnbserveAsync()
        {
            await _jsRuntime.InvokeVoidAsync("Blatternfly.Window.onClick"  , _dotNetObjRef);
            await _jsRuntime.InvokeVoidAsync("Blatternfly.Window.onKeyDown", _dotNetObjRef);
            await _jsRuntime.InvokeVoidAsync("Blatternfly.Window.onResize" , _dotNetObjRef);
            
            _canUseDom = await _jsRuntime.InvokeAsync<bool>("Blatternfly.Window.canUseDOM", null);
        } 
        
        public async Task<Size<int>> GetWindowSizeAsync()
        {
            return await _jsRuntime.InvokeAsync<Size<int>>("Blatternfly.Window.innerSize", null);
        }
    }
}
