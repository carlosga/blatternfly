using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public partial class CardTitle : BaseComponent
    {
        /// Sets the base component to render. defaults to div.
        [Parameter] public string Component { get; set; } = "div";

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(1, Component);
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", $"pf-c-card__title");
            builder.AddContent(4, ChildContent);
            builder.CloseElement();
        }
    }
}
