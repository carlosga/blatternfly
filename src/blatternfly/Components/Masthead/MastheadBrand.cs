using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class MastheadBrand : BaseComponent
    {
        /// Component type of the masthead brand.
        [Parameter] public MastheadBrandComponent Component { get; set; } = MastheadBrandComponent.a;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var component = Component == MastheadBrandComponent.a ? "a": "div";

            builder.OpenElement(1, component);
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", $"pf-c-masthead__brand {InternalCssClass}");
            builder.AddAttribute(4, "tabindex", "0");
            builder.AddContent(5, ChildContent);
            builder.CloseElement();
        }
    }
}
