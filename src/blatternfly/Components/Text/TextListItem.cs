using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class TextListItem : BaseComponent
    {
        [Parameter] public TextListItemVariants Component { get; set; } = TextListItemVariants.li;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index = 0;

            builder.OpenElement(index++, Component.ToString());
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "data-pf-content", "true");
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();
        }
    }
}
