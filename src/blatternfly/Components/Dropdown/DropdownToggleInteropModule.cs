using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blatternfly.Components
{
    public sealed class DropdownToggleInteropModule : IDropdownToggleInteropModule
    {
        private IJSObjectReference  _module;
        private readonly IJSRuntime _runtime;

        public DropdownToggleInteropModule(IJSRuntime runtime)
        {
            _runtime = runtime;
        }
        
        public async ValueTask ImportAsync()
        {
            _module = await _runtime.InvokeAsync<IJSObjectReference>("import", "./_content/Blatternfly/components/dropdown-toggle.js");
        }

        public async ValueTask DisposeAsync()
        {
            if (_module is not null)
            {
                await _module.DisposeAsync();
            }
        }

        public async ValueTask OnKeydown(DotNetObjectReference<Toggle> dotNetObjRef, ElementReference toggle)
        {
            await _module.InvokeVoidAsync("onKeyDown", dotNetObjRef, toggle);
        }
    }
}
