using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blatternfly.Components
{
    public sealed class DropdownInteropModule : IDropdownInteropModule
    {
        private IJSObjectReference  _module;
        private readonly IJSRuntime _runtime;

        public DropdownInteropModule(IJSRuntime runtime)
        {
            _runtime = runtime;
        }
        
        public async ValueTask ImportAsync()
        {
            _module = await _runtime.InvokeAsync<IJSObjectReference>("import", "./_content/Blatternfly/components/dropdown.js");
        }

        public async ValueTask DisposeAsync()
        {
            if (_module is not null)
            {
                await _module.DisposeAsync();
            }
        }

        public async ValueTask OnKeydown(DotNetObjectReference<Toggle> dotNetObjRef, string toggleId)
        {
            await _module.InvokeVoidAsync("onKeyDown", dotNetObjRef, toggleId);
        }
    }
}
