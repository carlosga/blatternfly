using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components;

public class InputGroupText : BaseComponent
{
    /// Component that wraps the input group text.
    [Parameter] public string Component { get; set; } = "span";

    /// Input group text variant.
    [Parameter]
    public InputGroupTextVariant Variant { get; set; } = InputGroupTextVariant.Default;

    private CssBuilder CssClass => new CssBuilder("pf-c-input-group__text")
        .AddClass("pf-m-plain", Variant == InputGroupTextVariant.Plain)
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
