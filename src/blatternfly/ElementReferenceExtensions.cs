using System.Threading.Tasks;
using Blatternfly;
using Microsoft.JSInterop;

namespace Microsoft.AspNetCore.Components
{
    internal static class ElementReferenceExtensions
    {
        internal static async ValueTask<BoundingClientRect> GetBoundingClientRect(this ElementReference el, IJSRuntime js)
        {
            return await js.InvokeAsync<BoundingClientRect>("Blatternfly.getBoundingClientRect", el);
        }

        internal static async ValueTask<Size<double>> GetOffsetSize(this ElementReference el, IJSRuntime js)
        {
            return await js.InvokeAsync<Size<double>>("Blatternfly.offsetSize", el);
        }
        
        internal static async ValueTask<Size<double>> GetScrollSize(this ElementReference el, IJSRuntime js)
        {
            return await js.InvokeAsync<Size<double>>("Blatternfly.scrollSize", el);
        }
        
        internal static async ValueTask ScrollLeft(this ElementReference el, IJSRuntime js, double scrollWidth)
        {
            await js.InvokeVoidAsync("Blatternfly.scrollLeft", el, scrollWidth);
        }
    }
}
