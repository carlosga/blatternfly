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

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var sizeClass = Size switch
            {
                SpinnerSize.Small      => "pf-m-sm",
                SpinnerSize.Medium     => "pf-m-md",
                SpinnerSize.Large      => "pf-m-lg",
                SpinnerSize.ExtraLarge => "pf-m-xl",
                _                      => null
            };

            builder.OpenElement(1, "span");
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", $"pf-c-spinner {sizeClass} {VisibilityClass}");
            builder.AddAttribute(4, "role", "progressbar");
            builder.AddAttribute(5, "aria-valuetext", AriaValueText);

            builder.OpenElement(6, "span");
            builder.AddAttribute(7, "class", "pf-c-spinner__clipper");
            builder.CloseElement();

            builder.OpenElement(8, "span");
            builder.AddAttribute(9, "class", "pf-c-spinner__lead-ball");
            builder.CloseElement();

            builder.OpenElement(10, "span");
            builder.AddAttribute(11, "class", "pf-c-spinner__tail-ball");
            builder.CloseElement();

            builder.AddContent(12, ChildContent);
            builder.CloseElement();
        }
    }
}
