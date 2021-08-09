using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class CardBody : BaseComponent
    {
        /// Sets the base component to render. defaults to div.
        [Parameter] public string Component { get; set; } = "div";

        /// Enables the body Content to fill the height of the card.
        [Parameter] public bool IsFilled { get; set; } = true;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var fillStyle = IsFilled ? null : "pf-m-no-fill";

            builder.OpenElement(1, Component);
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", $"pf-c-card__body {fillStyle} {InternalCssClass}");
            builder.AddContent(4, ChildContent);
            builder.CloseElement();
        }
    }
}
