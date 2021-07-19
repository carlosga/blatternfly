using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class TextList : BaseComponent
    {
        [Parameter] public TextListVariants Component { get; set; } = TextListVariants.ul;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index     = 0;
            var component = Component switch
            {
                TextListVariants.ul => "ul",
                TextListVariants.ol => "ol",
                TextListVariants.dl => "dl",
                _                   => null
            };

            builder.OpenElement(index++, component);
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "data-pf-content", "true");
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();
        }
    }
}
