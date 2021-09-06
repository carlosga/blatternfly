using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blatternfly.Interop
{
    public sealed class DomUtils : IDomUtils
    {
        private IJSObjectReference  _module;
        private readonly IJSRuntime _runtime;

        public DomUtils(IJSRuntime runtime)
        {
            _runtime = runtime;
        }

        public async ValueTask DisposeAsync()
        {
            if (_module is not null)
            {
                await _module.DisposeAsync();
            }
        }
        
        public async ValueTask ImportAsync()
        {
            _module = await _runtime.InvokeAsync<IJSObjectReference>("import", "./_content/Blatternfly/dom-utils/dom-utils.js");
        }
        
        public async ValueTask<BoundingClientRect> GetBoundingClientRectAsync(ElementReference el)
        {
            return await _module.InvokeAsync<BoundingClientRect>("getBoundingClientRect", el);
        }

        public async ValueTask<Size<double>> GetOffsetSizeAsync(ElementReference el)
        {
            return await _module.InvokeAsync<Size<double>>("offsetSize", el);
        }
        
        public async ValueTask<Size<double>> GetScrollSizeAsync(ElementReference el)
        {
            return await _module.InvokeAsync<Size<double>>("scrollSize", el);
        }
        
        public async ValueTask ScrollLeftAsync(ElementReference el, double scrollWidth)
        {
            await _module.InvokeVoidAsync("scrollLeft", el, scrollWidth);
        }
    }
}
