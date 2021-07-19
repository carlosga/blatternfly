using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public partial class Divider : BaseComponent
    {
        [Parameter] public DividerVariant Component { get; set; } = DividerVariant.hr;

        /// Flag to indicate the divider is vertical (must be in a flex layout).
        [Parameter] public bool IsVertical { get; set; }

        /// Insets at various breakpoints.
        [Parameter] public Inset Inset { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index         = 0;
            var verticalClass = IsVertical ? "pf-m-vertical" : null;

            builder.OpenElement(index++, Component.ToString());
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", $"pf-c-divider {verticalClass} {Inset?.CssClass}");
            if (Component != DividerVariant.hr)
            {
                builder.AddAttribute(index++, "role", "separator");
            }
            builder.CloseElement();
        }
    }
}
