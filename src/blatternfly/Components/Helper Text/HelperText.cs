using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class HelperText : BaseComponent
    {
        /// Component type of the helper text container.
        [Parameter] public HelperTextComponent Component { get; set; } = HelperTextComponent.div;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index = 0;
            var component = Component switch
            {
                HelperTextComponent.div => "div",
                HelperTextComponent.ul  => "ul",
                _                       => "div"
            };

            builder.OpenElement(index++, component);
            builder.AddAttribute(index++, "class", "pf-c-helper-text");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();
        }
    }
}
