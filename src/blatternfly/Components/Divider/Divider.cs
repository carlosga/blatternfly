using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class Divider : BaseComponent
    {
        [Parameter] public DividerVariant Component { get; set; } = DividerVariant.hr;

        /// Flag to indicate the divider is vertical (must be in a flex layout).
        [Parameter] public bool IsVertical { get; set; }

        /// Insets at various breakpoints.
        [Parameter] public Inset Inset { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var verticalClass = IsVertical ? "pf-m-vertical" : null;

            builder.OpenElement(1, Component.ToString());
            builder.AddMultipleAttributes(2, AdditionalAttributes);
            builder.AddAttribute(3, "class", $"pf-c-divider {verticalClass} {Inset?.CssClass}");
            if (Component != DividerVariant.hr)
            {
                builder.AddAttribute(4, "role", "separator");
            }
            builder.CloseElement();
        }
    }
}
