using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;

namespace Blatternfly.Components
{
    public class DropdownItem : BaseComponent
    {
        [CascadingParameter] public Dropdown ParentDropdown { get; set; }
        [CascadingParameter] public DropdownMenu ParentDropdownMenu { get; set; }

        [DisallowNull] public ElementReference Element { get; protected set; }

        [Inject] IJSRuntime JS { get; set; }

        /// Class applied to list element.
        [Parameter] public string ListItemCssClass { get; set; }

        /// Indicates which component will be used as dropdown item. Will have className injected if React.isValidElement(component).
        [Parameter] public string Component { get; set; } = "a";

        /// Variant of the item. The 'icon' variant should use DropdownItemIcon to wrap contained icons or images.
        [Parameter] public DropdownMenuItemVariant Variant { get; set; } = DropdownMenuItemVariant.Item;

        /// Role for the item.
        [Parameter] public string Role { get; set; } = "menuitem";

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

        /// An image to display within the InternalDropdownItem, appearing before any component children.
        [Parameter] public RenderFragment Icon { get; set; }
        
        /// Initial focus on the item when the menu is opened (Note: Only applicable to one of the items).
        [Parameter] public bool AutoFocus { get; set; }        
        
        [Parameter] public int Index { get; set; }
        [Parameter] public string Key { get; set; }
        [Parameter] public string Value { get; set; }
        
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index              = 0;
            var disabledClass = IsDisabled ? "pf-m-disabled" : null;
            var plainClass    = IsPlainText ? "pf-m-plain" : null;
            var hoverClass    = IsHovered ? "pf-m-hover" : null;
            var iconClass     = Icon is not null ? "pf-m-icon" : null;
            var cssClass      = !string.IsNullOrEmpty(ParentDropdown?.ItemClass)
                ? ParentDropdown.ItemClass
                    : "pf-c-dropdown__menu-item";

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
            builder.AddAttribute(index++, "aria-disabled", IsDisabled ? "true" : "false");
            builder.AddAttribute(index++, "disabled", IsDisabled);

            if (Component == "button")
            {
                builder.AddAttribute(index++, "type", "button");
            }

            if (Icon is not null)
            {
                builder.OpenElement(index++, "span");
                builder.AddAttribute(index++, "class", "pf-c-dropdown__menu-item-icon");
                builder.AddContent(index++, Icon);
                builder.CloseElement();
            }

            builder.AddContent(index++, ChildContent);
            builder.CloseElement();

            builder.AddElementReferenceCapture(index++, __inputReference => Element = __inputReference);
            builder.CloseElement();
        }
        
        internal async Task Focus()
        {
            await Element.FocusAsync();
        }
        
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (Role != "separator")
            {
                ParentDropdownMenu.RegisterItem(this);
            }
        }
        
        private async Task ClickHandler(MouseEventArgs args)
        {
            if (!IsDisabled)
            {
                await ParentDropdown.Select(this);
                await OnClick.InvokeAsync(args);
            }
        }        
    }
}
