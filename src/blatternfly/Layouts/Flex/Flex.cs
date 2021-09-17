using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Layouts
{
    public class Flex : LayoutBase
    {
        /// Spacers at various breakpoints.
        [Parameter] public FlexSpacer Spacer { get; set; } 

        /// Space items at various breakpoints.
        [Parameter] public FlexSpaceItem SpaceItems { get; set; }

        /// Whether to add flex: grow at various breakpoints.
        [Parameter] public FlexGrow Grow { get; set; } 

        /// Whether to add flex: shrink at various breakpoints.
        [Parameter] public FlexShrink Shrink { get; set; }

        /// Value to add for flex property at various breakpoints.
        /// This is the shorthand for flex-grow, flex-shrink and flex-basis combined.
        [Parameter] public FlexShorthand FlexShorthand { get; set;}

        /// Value to add for flex-direction property at various breakpoints.
        [Parameter] public FlexDirection Direction { get; set; }

        /// Value to add for align-items property at various breakpoints.
        [Parameter] public AlignItem AlignItems { get; set; }

        /// Value to add for align-content property at various breakpoints.
        [Parameter] public AlignContent AlignContent { get; set; }

        /// Value to add for align-self property at various breakpoints.
        [Parameter] public AlignSelf AlignSelf { get; set; }

        /// Value to use for margin: auto at various breakpoints.
        [Parameter] public Alignment Align { get; set; }

        /// Value to add for justify-content property at various breakpoints.
        [Parameter] public JustifyContent JustifyContent { get; set; }

        /// Value to set to display property at various breakpoints.
        [Parameter] public FlexDisplay Display { get; set; }

        /// Whether to set width: 100% at various breakpoints.
        [Parameter] public FlexFullWidth FullWidth { get; set; }

        /// Value to set for flex-wrap property at various breakpoints.
        [Parameter] public FlexWrap FlexWrap { get; set; }

        /// Modifies the flex layout element order property.
        [Parameter] public FlexOrder Order { get; set; }
        
        /// Sets the base component to render. defaults to div.
        [Parameter] public string Component { get; set; } = "div";

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var tempCssClass = $"{Spacer?.CssClass} {SpaceItems?.CssClass} {Grow?.CssClass} {Shrink?.CssClass} {FlexShorthand?.CssClass} {Direction?.CssClass} {AlignItems?.CssClass} {AlignContent?.CssClass} {AlignSelf?.CssClass} {Align?.CssClass} {JustifyContent?.CssClass} {Display?.CssClass} {FullWidth?.CssClass} {FlexWrap?.CssClass} {InternalCssClass}";
            var cssClass     = string.IsNullOrWhiteSpace(tempCssClass) ? null: tempCssClass;
            var cssStyle     = $"{InternalCssStyle} {Order?.CssStyle}";
            
            if (string.IsNullOrWhiteSpace(cssStyle))
            {
                cssStyle = null;
            }

            builder.OpenElement(1, Component);
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", $"pf-l-flex {cssClass}");
            builder.AddAttribute(4, "style", cssStyle);
            builder.AddContent(5, ChildContent);
            builder.CloseElement();
        }
    }
}
