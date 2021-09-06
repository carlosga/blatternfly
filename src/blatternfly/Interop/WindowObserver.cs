using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Blatternfly.Events;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace Blatternfly.Interop
{
    public sealed class WindowObserver : IWindowObserver
    {
        private IJSObjectReference                             _module;
        private readonly IJSRuntime                            _runtime;
        private readonly DotNetObjectReference<WindowObserver> _dotNetObjRef;
        private readonly Subject<MouseEvent>                   _clickStream;
        private readonly Subject<KeyboardEventArgs>            _keydownStream;
        private readonly Subject<ResizeEvent>                  _resizeStream;
        
        private bool _canUseDom;

        public bool                           CanUseDom { get => _canUseDom; }
        public IObservable<MouseEvent>        OnClick   { get => _clickStream.AsObservable(); }
        public IObservable<KeyboardEventArgs> OnKeydown { get => _keydownStream.AsObservable(); }
        public IObservable<ResizeEvent>       OnResize  { get => _resizeStream.AsObservable(); }
    
        public WindowObserver(IJSRuntime runtime)
        {
            _runtime       = runtime;
            _dotNetObjRef  = DotNetObjectReference.Create(this);
            _clickStream   = new Subject<MouseEvent>();
            _keydownStream = new Subject<KeyboardEventArgs>();
            _resizeStream  = new Subject<ResizeEvent>();
        }

        public async ValueTask DisposeAsync()
        {
            if (_module is not null)
            {
                await _module.DisposeAsync();
            }
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
        
        public async Task ImportAsync()
        {
            _module = await _runtime.InvokeAsync<IJSObjectReference>("import", "./_content/Blatternfly/window/window.js");
            
            await _module.InvokeVoidAsync("onClick"  , _dotNetObjRef);
            await _module.InvokeVoidAsync("onKeyDown", _dotNetObjRef);
            await _module.InvokeVoidAsync("onResize" , _dotNetObjRef);
            
            _canUseDom = await _module.InvokeAsync<bool>("canUseDOM", null);
        } 
        
        public async Task<Size<int>> GetWindowSizeAsync()
        {
            return await _module.InvokeAsync<Size<int>>("innerSize", null);
        }
    }
}
