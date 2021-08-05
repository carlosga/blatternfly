 using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class Spinner : BaseComponent
    {
        /// Size variant of progress.
        [Parameter] public SpinnerSize Size { get; set; } = SpinnerSize.ExtraLarge;

        //// Aria value text.
        [Parameter] public string AriaValueText { get; set; } = "Loading ...";
        
        /** Whether to use an SVG (new) rather than a span (old) */
        [Parameter] public bool IsSVG { get; set; }
        
        /** Diameter of spinner set as CSS variable */
        [Parameter] public string Diameter { get; set; }        

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index     = 1;
            var component = IsSVG ? "svg" : "span";
            var sizeClass = Size switch
            {
                SpinnerSize.Small      => "pf-m-sm",
                SpinnerSize.Medium     => "pf-m-md",
                SpinnerSize.Large      => "pf-m-lg",
                SpinnerSize.ExtraLarge => "pf-m-xl",
                _                      => null
            };

            builder.OpenElement(index++, component);
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", $"pf-c-spinner {sizeClass}");
            builder.AddAttribute(index++, "role", "progressbar");
            builder.AddAttribute(index++, "aria-valuetext", AriaValueText);
            
            if (IsSVG)
            {
                builder.AddAttribute(index++, "viewBox", "0 0 100 100");
            }
            if (!string.IsNullOrEmpty(Diameter))
            {
                builder.AddAttribute(index++, "style", $"--pf-c-spinner--diameter:{Diameter}");
            }

            if (IsSVG)
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
