using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class Spinner : BaseComponent
    {
        /// Size variant of progress.
        [Parameter] public SpinnerSize Size { get; set; } = SpinnerSize.ExtraLarge;

        //// Aria value text.
        [Parameter] public string AriaValueText { get; set; } = "Loading...";
        
        /** Whether to use an SVG (new) rather than a span (old) */
        [Parameter] public bool IsSvg { get; set; }
        
        /** Diameter of spinner set as CSS variable */
        [Parameter] public string Diameter { get; set; }        

        private CssBuilder CssClass => new CssBuilder("pf-c-spinner")
            .AddClass("pf-m-sm", Size == SpinnerSize.Small)
            .AddClass("pf-m-md", Size == SpinnerSize.Medium)
            .AddClass("pf-m-lg", Size == SpinnerSize.Large)
            .AddClass("pf-m-xl", Size == SpinnerSize.ExtraLarge);

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index     = 1;
            var component = IsSvg ? "svg" : "span";

            builder.OpenElement(index++, component);
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "aria-valuetext", AriaValueText);
            builder.AddAttribute(index++, "class", CssClass);
            builder.AddAttribute(index++, "role", "progressbar");
            
            if (IsSvg)
            {
                builder.AddAttribute(index++, "viewBox", "0 0 100 100");
            }
            if (!string.IsNullOrEmpty(Diameter))
            {
                builder.AddAttribute(index++, "style", $"--pf-c-spinner--diameter:{Diameter}");
            }

            if (IsSvg)
            {
                builder.OpenElement(index++, "circle");
                builder.AddAttribute(index++, "class", "pf-c-spinner__path");
                builder.AddAttribute(index++, "cx", "50");
                builder.AddAttribute(index++, "cy", "50");
                builder.AddAttribute(index++, "r", "45");
                builder.AddAttribute(index++, "fill", "none");
                builder.CloseElement();
            }
            else
            {
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-spinner__clipper");
                builder.CloseElement();

                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-spinner__lead-ball");
                builder.CloseElement();

                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-spinner__tail-ball");
                builder.CloseElement();
            }

            builder.CloseElement();
        }
    }
}
