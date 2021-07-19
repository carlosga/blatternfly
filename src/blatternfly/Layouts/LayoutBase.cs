using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Blatternfly.Layouts
{
    public abstract class LayoutBase : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

        [Parameter] public virtual RenderFragment ChildContent { get; set; }

        /// Visibility at various breakpoints.
        [Parameter] public Visibility Visibility { get; set; }
        
        protected string VisibilityClass { get => Visibility?.CssClass; }        
    }
}
