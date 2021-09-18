using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Blatternfly.Interop
{
    public interface IDomUtils : IAsyncDisposable
    {
        ValueTask<BoundingClientRect> GetBoundingClientRectAsync(ElementReference el);

        ValueTask<Size<double>> GetOffsetSizeAsync(ElementReference el);

        ValueTask<Size<double>> GetScrollSizeAsync(ElementReference el);

        ValueTask ScrollLeftAsync(ElementReference el, double scrollWidth);
    }
}
