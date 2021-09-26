using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Layouts
{
    public class Split : LayoutBase
    {
        /// Adds space between children.
        [Parameter] public bool HasGutter { get; set; }
        
        /// Allows children to wrap.
        [Parameter] public bool IsWrappable { get; set; }        

        /// Sets the base component to render. defaults to div.
        [Parameter] public string Component { get; set; } = "div";

        private CssBuilder CssClass => new CssBuilder("pf-l-split")
            .AddClass("pf-m-gutter", HasGutter)
            .AddClass("pf-m-wrap"  , IsWrappable);
        
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(1, Component);
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", CssClass);
            builder.AddContent(4, ChildContent);
            builder.CloseElement();
        }
    }
}
