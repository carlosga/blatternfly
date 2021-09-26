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

        private CssBuilder CssClass => new CssBuilder("pf-c-card__body")
            .AddClass("pf-m-no-fill", !IsFilled)
            .AddClassFromAttributes(AdditionalAttributes);
        
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(1, Component);
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", CssClass);
            builder.AddContent(4, ChildContent);
            builder.CloseElement();
        }
    }
}
