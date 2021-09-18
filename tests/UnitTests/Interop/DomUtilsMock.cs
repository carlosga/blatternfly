using System.Threading.Tasks;
using Blatternfly.Interop;
using Microsoft.AspNetCore.Components;

namespace Blatternfly.UnitTests.Interop
{
    public sealed class DomUtilsMock : IDomUtils
    {
        public ValueTask DisposeAsync()
        {
            return ValueTask.CompletedTask;
        }
        
        public ValueTask<BoundingClientRect> GetBoundingClientRectAsync(ElementReference el)
        {
            return ValueTask.FromResult<BoundingClientRect>(new BoundingClientRect { Left = 0, Right = 0 });
        }

        public ValueTask<Size<double>> GetOffsetSizeAsync(ElementReference el)
        {
            return ValueTask.FromResult<Size<double>>(new Size<double>());
        }

        public ValueTask<Size<double>> GetScrollSizeAsync(ElementReference el)
        {
            return ValueTask.FromResult<Size<double>>(new Size<double>());
        }

        public ValueTask ScrollLeftAsync(ElementReference el, double scrollWidth)
        {
            return ValueTask.CompletedTask;
        }
    }
}
