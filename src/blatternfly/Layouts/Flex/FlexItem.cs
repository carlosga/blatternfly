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
        
        private CssBuilder CssClass => new CssBuilder()
            .AddClass(Spacer?.CssClass)
            .AddClass(Grow?.CssClass)
            .AddClass(Shrink?.CssClass)
            .AddClass(Flex?.CssClass)
            .AddClass(AlignSelf?.CssClass)
            .AddClass(Align?.CssClass)
            .AddClass(FullWidth?.CssClass);
        
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var cssStyle = $"{InternalCssStyle} {Order?.CssStyle}";
            
            builder.OpenElement(1, Component);
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", CssClass);
            builder.AddAttribute(4, "style", string.IsNullOrWhiteSpace(cssStyle) ? null : cssStyle);
            builder.AddContent(5, ChildContent);
            builder.CloseElement();
        }
    }
}