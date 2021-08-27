
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace Blatternfly.Components
{
    public class DataListText : BaseComponent
    {
        /// Determines which element to render as a data list text. Usually div or span.
        [Parameter] public string Component { get; set; } = "span";
        
        /// Determines which wrapping modifier to apply to the data list text.
        [Parameter] public DataListWrapModifier? WrapModifier { get; set; }
            
        /// Text to display on the tooltip.
        [Parameter] public string Tooltip { get; set; }
        
        /// Callback used to create the tooltip if text is truncated.
        [Parameter] public EventCallback<MouseEventArgs> OnMouseEnter { get; set; }
        
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var wrapClass = WrapModifier switch
            {
                DataListWrapModifier.Nowrap    => "pf-m-nowrap",
                DataListWrapModifier.Truncate  => "pf-m-truncate",
                DataListWrapModifier.BreakWord => "pf-m-break-word",
                _                              => null
            };
            
            builder.OpenElement(1, Component);
            builder.AddAttribute(2, "class", $"pf-c-data-list__text {wrapClass}");
            builder.AddAttribute(3, "onmouseenter", EventCallback.Factory.Create(this, OnMouseEnter));
            builder.AddContent(4, ChildContent);
            builder.CloseElement();
        }
    }
}
