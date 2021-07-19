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
            var index = 0;

            var sizeClass = Size switch
            {
                SpinnerSize.Small      => "pf-m-sm",
                SpinnerSize.Medium     => "pf-m-md",
                SpinnerSize.Large      => "pf-m-lg",
                SpinnerSize.ExtraLarge => "pf-m-xl",
                _                      => null
            };

            builder.OpenElement(index++, "span");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", $"pf-c-spinner {sizeClass} {VisibilityClass}");
            builder.AddAttribute(index++, "role", "progressbar");
            builder.AddAttribute(index++, "aria-valuetext", AriaValueText);

            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "class", "pf-c-spinner__clipper");
            builder.CloseElement();

            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "class", "pf-c-spinner__lead-ball");
            builder.CloseElement();

            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "class", "pf-c-spinner__tail-ball");
            builder.CloseElement();

            builder.AddContent(index++, ChildContent);
            builder.CloseElement();
        }
    }
}
