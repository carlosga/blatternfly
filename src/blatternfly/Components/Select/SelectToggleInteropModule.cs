using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blatternfly.Components
{
    public sealed class SelectToggleInteropModule : ISelectToggleInteropModule
    {
        private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

        public SelectToggleInteropModule(IJSRuntime runtime)
        {
            _moduleTask = new Lazy<Task<IJSObjectReference>>(() => runtime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Blatternfly/components/select-toggle.js").AsTask());
        }
        
        public async ValueTask DisposeAsync()
        {
            if (_moduleTask.IsValueCreated)
            {
                var module = await _moduleTask.Value;
                await module.DisposeAsync();
            }
        }

        public async ValueTask OnKeydown(DotNetObjectReference<SelectToggle> dotNetObjRef, ElementReference toggle)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("onKeyDown", dotNetObjRef, toggle);
        }        
    }
}
