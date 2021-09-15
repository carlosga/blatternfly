using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blatternfly.Components
{
    public sealed class SelectToggleInteropModule : ISelectToggleInteropModule
    {
        private IJSObjectReference  _module;
        private readonly IJSRuntime _runtime;

        public SelectToggleInteropModule(IJSRuntime runtime)
        {
            _runtime = runtime;
        }
        
        public async ValueTask ImportAsync()
        {
            _module = await _runtime.InvokeAsync<IJSObjectReference>("import", "./_content/Blatternfly/components/select-toggle.js");
        }

        public async ValueTask DisposeAsync()
        {
            if (_module is not null)
            {
                await _module.DisposeAsync();
            }
        }

        public async ValueTask OnKeydown(DotNetObjectReference<SelectToggle> dotNetObjRef, ElementReference toggle)
        {
            await _module.InvokeVoidAsync("onKeyDown", dotNetObjRef, toggle);
        }        
    }
}
