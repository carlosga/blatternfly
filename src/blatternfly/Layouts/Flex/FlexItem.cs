using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Layouts
{
    public class FlexItem : LayoutBase
    {
        /// Spacers at various breakpoints.
        [Parameter] public FlexSpacer Spacer { get; set; }

        /// Whether to add flex: grow at various breakpoints.
        [Parameter] public FlexGrow Grow { get; set; }

        /// Whether to add flex: shrink at various breakpoints.
        [Parameter] public FlexShrink Shrink { get; set; }

        /// Value to add for flex property at various breakpoints.
        [Parameter] public FlexShorthand Flex { get; set; }

        /// Value to add for align-self property at various breakpoints.
        [Parameter] public AlignSelf AlignSelf { get; set; }

        /// Value to use for margin: auto at various breakpoints
        [Parameter] public Alignment Align { get; set; }

        /// Whether to set width: 100% at various breakpoints.
        [Parameter] public FlexFullWidth FullWidth { get; set; }

        /// Modifies the flex layout element order property.
        [Parameter] public FlexOrder Order { get; set; }
        
        /// Sets the base component to render. defaults to div.
        [Parameter] public string Component { get; set; } = "div";
        
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var cssClass = $"{Spacer?.CssClass} {Grow?.CssClass} {Shrink?.CssClass} {Flex?.CssClass} {AlignSelf?.CssClass} {Align?.CssClass} {FullWidth?.CssClass}";
            
            builder.OpenElement(1, Component);
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", string.IsNullOrWhiteSpace(cssClass) ? null : cssClass);
            builder.AddAttribute(4, "style", Order?.CssStyle);
            builder.AddContent(5, ChildContent);
            builder.CloseElement();
        }
    }
}
