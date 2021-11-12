using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components;

public class HelperText : BaseComponent
{
    /// Component type of the helper text container.
    [Parameter] public HelperTextComponent Component { get; set; } = HelperTextComponent.div;

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(1, Component.ToString());
        builder.AddAttribute(2, "class", "pf-c-helper-text");
        builder.AddMultipleAttributes(3, AdditionalAttributes);
        builder.AddContent(4, ChildContent);
        builder.CloseElement();
    }
}
