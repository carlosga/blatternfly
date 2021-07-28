using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blatternfly.Components
{
    public class DropdownItem : BaseComponent
    {
        [CascadingParameter] public Dropdown Parent { get; set; }

        /// Class applied to list element.
        [Parameter] public string ListItemCssClass { get; set; }

        /// Indicates which component will be used as dropdown item. Will have className injected if React.isValidElement(component).
        [Parameter] public string Component { get; set; } = "a";
        
        /// Variant of the item. The 'icon' variant should use DropdownItemIcon to wrap contained icons or images.
        [Parameter] public DropdownMenuItemVariant Variant { get; set; } = DropdownMenuItemVariant.Item;

        /// Role for the item.
        [Parameter] public virtual string Role { get; set; } = "menuitem";

        /// Render dropdown item as disabled option.
        [Parameter] public bool IsDisabled { get; set; }
        
        /// Render dropdown item as a non-interactive item.
        [Parameter] public bool IsPlainText { get; set; }

        /// Forces display of the hover state of the element.
        [Parameter] public bool IsHovered { get; set; }

        /// Default hyperlink location.
        [Parameter] public string Href { get; set; } = string.Empty;

        /// tabIndex to use, null to unset it.
        [Parameter] public int TabIndex { get; set; } = -1;

        /// Callback for click event.
        [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// ID for the component element.
        [Parameter] public string ComponentId { get; set; }

        [Parameter] public int Index { get; set; }

        [Parameter] public string Key { get; set; }

        [Parameter] public string Value { get; set; }

        /// An image to display within the InternalDropdownItem, appearing before any component children.
        [Parameter] public RenderFragment Icon { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index              = 0;
            var cssClass      = !string.IsNullOrEmpty(Parent?.ItemClass) ? Parent.ItemClass : "pf-c-dropdown__menu-item";
            var disabledClass = IsDisabled ? "pf-m-disabled" : null;
            var plainClass    = IsPlainText ? "pf-m-plain" : null;
            var hoverClass    = IsHovered ? "pf-m-hover" : null;
            var iconClass     = Icon != null ? "pf-m-icon" : null;

            builder.OpenElement(index++, "li");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", ListItemCssClass);
            builder.AddAttribute(index++, "role", Role);
            builder.AddAttribute(index++, "onclick",  EventCallback.Factory.Create(this, ClickHandler));
            builder.AddEventStopPropagationAttribute(index++, "onclick", true);

            builder.OpenElement(index++, Component);
            builder.AddAttribute(index++, "id", ComponentId);
            builder.AddAttribute(index++, "class", $"{cssClass} {iconClass} {disabledClass} {plainClass} {hoverClass}");
            builder.AddAttribute(index++, "tabindex", IsDisabled ? -1 : TabIndex);
            builder.AddAttribute(index++, "aria-disabled", IsDisabled ? "true" : null);
            builder.AddAttribute(index++, "disabled", IsDisabled);

            if (Component == "button")
            {
                builder.AddAttribute(index++, "type", "button");
            }

            if (Icon != null)
            {
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-dropdown__menu-item-icon");
                builder.AddContent(index++, Icon);
                builder.CloseElement();
            }

            builder.AddContent(index++, ChildContent);
            builder.CloseElement();

            builder.CloseElement();
        }

        private async Task ClickHandler(MouseEventArgs args)
        {
            if (!IsDisabled)
            {
                await Parent.Select(this);
                await OnClick.InvokeAsync(args);
            }
        }
    }
}
