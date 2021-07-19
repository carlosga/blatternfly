using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public partial class CardBody : BaseComponent
    {
        /// Sets the base component to render. defaults to div.
        [Parameter] public string Component { get; set; } = "div";

        /// Enables the body Content to fill the height of the card.
        [Parameter] public bool IsFilled { get; set; } = true;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index     = 0;
            var fillStyle = IsFilled ? string.Empty : "pf-m-no-fill";

            builder.OpenElement(index++, Component);
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", $"pf-c-card__body {fillStyle}");
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();
        }
    }
}
