using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blatternfly.Components
{
    public class FocusTrapInteropModule : IFocusTrapInteropModule
    {
        private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

        public FocusTrapInteropModule(IJSRuntime runtime)
        {
            _moduleTask = new Lazy<Task<IJSObjectReference>>(() => runtime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Blatternfly/components/focus-trap-zone.js").AsTask());
        }
        
        public async ValueTask DisposeAsync()
        {
            if (_moduleTask.IsValueCreated)
            {
                var module = await _moduleTask.Value;
                await module.DisposeAsync();
            }
        }

        public async Task Create(DotNetObjectReference<FocusTrap> dotNetObjRef, ElementReference reference, FocusTrapOptions options)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("create", dotNetObjRef, reference);
        }

        public async Task Activate()
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("activate");
        }

        public async Task Deactivate()
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("deactivate");
        }
        
        public async Task Pause()
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("pause");
        }

        public async Task Unpause()
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("unpause");
        }
    }
}
