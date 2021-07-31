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
        
        /// Flag indicating if hitting enter on an item also triggers an arrow down key press.
        [Parameter] public bool EnterTriggersArrowDown { get; set; }        

        /// An image to display within the InternalDropdownItem, appearing before any component children.
        [Parameter] public RenderFragment Icon { get; set; }
        
        /// Initial focus on the item when the menu is opened (Note: Only applicable to one of the items).
        [Parameter] public bool AutoFocus { get; set; }        
        
        /// A short description of the dropdown item, displayed under the dropdown item content.
        [Parameter] public RenderFragment Description { get; set; }
        
        [Parameter] public int Index { get; set; } = -1;
        
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index = 0;
            var disabledClass = IsDisabled ? "pf-m-disabled" : null;
            var plainClass    = IsPlainText ? "pf-m-plain" : null;
            var iconClass     = Icon is not null ? "pf-m-icon" : null;
            var descriptionClass   = Description is not null ? "pf-m-description" : null;
            var itemClass      = !string.IsNullOrEmpty(ParentDropdown?.ItemClass)
                ? ParentDropdown.ItemClass
                : "pf-c-dropdown__menu-item";

            builder.OpenElement(index++, "li");
            builder.AddMultipleAttributes(index++, AdditionalAttributes);
            builder.AddAttribute(index++, "class", ListItemCssClass);
            builder.AddAttribute(index++, "role", Role);
            builder.AddAttribute(index++, "onkeydown",  EventCallback.Factory.Create(this, KeydownHandler));
            builder.AddEventPreventDefaultAttribute(index++, "onkeydown", true);
            builder.AddAttribute(index++, "onkeypress",  EventCallback.Factory.Create(this, KeypressHandler));
            builder.AddEventPreventDefaultAttribute(index++, "onkeypress", true);
            builder.AddAttribute(index++, "onclick",  EventCallback.Factory.Create(this, ClickHandler));
            builder.AddEventPreventDefaultAttribute(index++, "onclick", true);

            builder.OpenElement(index++, Component);
            builder.AddAttribute(index++, "id", ComponentId);
            builder.AddAttribute(index++, "class", $"{itemClass} {iconClass} {disabledClass} {plainClass} {descriptionClass}");
            builder.AddAttribute(index++, "tabindex", IsDisabled ? -1 : TabIndex);
            builder.AddAttribute(index++, "disabled", IsDisabled);
            
            if (Component == "a")
            {
                builder.AddAttribute(index++, "aria-disabled", IsDisabled ? "true" : "false");
            }
            else if (Component == "button")
            {
                builder.AddAttribute(index++, "aria-disabled", IsDisabled ? "true" : "false");
                builder.AddAttribute(index++, "type", "button");
            }

            if (Description is not null)
            {
                builder.OpenElement(index++, "div");
                builder.AddAttribute(index++, "class", "pf-c-dropdown__menu-item-main");

                if (Icon is not null)
                {
                    builder.OpenElement(index++, "span");
                    builder.AddAttribute(index++, "class", "pf-c-dropdown__menu-item-icon");
                    builder.AddContent(index++, Icon);
                    builder.CloseElement();
                }

                builder.AddContent(index++, ChildContent);
                
                builder.CloseElement();

                builder.OpenElement(index++, "div");
                builder.AddAttribute(index++, "class", "pf-m-description");
                builder.AddContent(index++, Description);
                builder.CloseElement();
            }
            else
            {
                if (Icon is not null)
                {
                    builder.OpenElement(index++, "span");
                    builder.AddAttribute(index++, "class", "pf-c-dropdown__menu-item-icon");
                    builder.AddContent(index++, Icon);
                    builder.CloseElement();
                }

                builder.AddContent(index++, ChildContent);
            }
            
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

            ParentDropdownMenu.RegisterItem(this);
        }
        
        private async Task ClickHandler(MouseEventArgs args)
        {
            if (!IsDisabled)
            {
                await OnClick.InvokeAsync(args);
                await ParentDropdown.Select(this);
            }
        }
        
        private Task KeydownHandler(KeyboardEventArgs args)
        {
            // Detected key press on this item, notify the menu parent so that the appropriate item can be focused
            // const innerIndex = event.target === this.ref.current ? 0 : 1;
            // if (!this.props.customChild) {
            //     event.preventDefault();
            // }
            // if (event.key === 'ArrowUp') {
            //     this.props.context.keyHandler(this.props.index, innerIndex, KEYHANDLER_DIRECTION.UP);
            // } else if (event.key === 'ArrowDown') {
            //     this.props.context.keyHandler(this.props.index, innerIndex, KEYHANDLER_DIRECTION.DOWN);
            // } else if (event.key === 'ArrowRight') {
            //     this.props.context.keyHandler(this.props.index, innerIndex, KEYHANDLER_DIRECTION.RIGHT);
            // } else if (event.key === 'ArrowLeft') {
            //     this.props.context.keyHandler(this.props.index, innerIndex, KEYHANDLER_DIRECTION.LEFT);
            // } else if (event.key === 'Enter' || event.key === ' ') {
            //     event.target.click();
            //     this.props.enterTriggersArrowDown &&
            //         this.props.context.keyHandler(this.props.index, innerIndex, KEYHANDLER_DIRECTION.DOWN);
            // }            
            return Task.CompletedTask;
        }
        
        private Task KeypressHandler(KeyboardEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}
