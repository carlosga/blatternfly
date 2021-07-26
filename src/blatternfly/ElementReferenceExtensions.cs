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

        internal static async ValueTask<double> GetOffsetWidth(this ElementReference el, IJSRuntime js)
        {
            return await js.InvokeAsync<double>("Blatternfly.offsetWidth", el);
        }
    }
}
