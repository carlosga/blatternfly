using System.Threading.Tasks;
using Blatternfly.Interop;

namespace Blatternfly.Components;

public class DropdownItem : BaseComponent
{
    [CascadingParameter] public Dropdown ParentDropdown { get; set; }
    [CascadingParameter] public DropdownMenu ParentDropdownMenu { get; set; }

    /// Class applied to list element.
    [Parameter] public string ListItemCssClass { get; set; }

    /// Indicates which component will be used as dropdown item. Will have class injected if React.isValidElement(component).
    [Parameter] public string Component { get; set; } = "a";

    /// Role for the item.
    [Parameter] public string Role { get; set; } = "menuitem";

    /// Render dropdown item as disabled option.
    [Parameter] public bool IsDisabled { get; set; }

    /// Render dropdown item as aria-disabled option.
    [Parameter] public bool IsAriaDisabled { get; set; }

    /// Render dropdown item as a non-interactive item.
    [Parameter] public bool IsPlainText { get; set; }

    /// Forces display of the hover state of the element.
    [Parameter] public bool IsHovered { get; set; }

    /// Default hyperlink location.
    [Parameter] public string Href { get; set; } = string.Empty;

    /// tabIndex to use, null to unset it.
    [Parameter] public int? TabIndex { get; set; } = -1;

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

    public ElementReference Element { get; protected set; }

    private string CssClass => new CssBuilder()
        .AddClass("pf-c-dropdown__menu-item", string.IsNullOrEmpty(ParentDropdown?.ItemClass))
        .AddClass(ParentDropdown.ItemClass  , !string.IsNullOrEmpty(ParentDropdown?.ItemClass))
        .AddClass("pf-m-icon"               , Icon is not null)
        .AddClass("pf-m-disabled"           , IsDisabled)
        .AddClass("pf-m-aria-disabled"      , IsAriaDisabled)
        .AddClass("pf-m-plain"              , IsPlainText)
        .AddClass("pf-m-description"        , Description is not null)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    // $"{itemClass} {iconClass} {disabledClass} {ariaDisabledClass} {plainClass} {descriptionClass}"

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var index    = 0;
        var disabled = IsDisabled || IsAriaDisabled ? "true" : null;

        builder.OpenElement(index++, "li");
        builder.AddMultipleAttributes(index++, AdditionalAttributes);
        builder.AddAttribute(index++, "class", ListItemCssClass);
        builder.AddAttribute(index++, "role", Role);
        builder.AddAttribute(index++, "onkeydown",  EventCallback.Factory.Create<KeyboardEventArgs>(this, KeydownHandler));
        builder.AddEventPreventDefaultAttribute(index++, "onkeydown", true);
        builder.AddAttribute(index++, "onkeypress",  EventCallback.Factory.Create<KeyboardEventArgs>(this, KeypressHandler));
        builder.AddEventPreventDefaultAttribute(index++, "onkeypress", true);
        builder.AddAttribute(index++, "onclick",  EventCallback.Factory.Create<MouseEventArgs>(this, ClickHandler));
        builder.AddEventPreventDefaultAttribute(index++, "onclick", true);

        builder.OpenElement(index++, Component);
        builder.AddAttribute(index++, "id", ComponentId);
        builder.AddAttribute(index++, "class", CssClass);
        builder.AddAttribute(index++, "tabindex", IsDisabled || IsAriaDisabled ? -1 : TabIndex);

        if (Component == "a")
        {
            builder.AddAttribute(index++, "aria-disabled", disabled);
        }
        else if (Component == "button")
        {
            builder.AddAttribute(index++, "aria-disabled", disabled);
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

        builder.AddElementReferenceCapture(index++, __inputReference => Element = __inputReference);
        builder.CloseElement();
        builder.CloseElement();
    }

    internal async Task FocusAsync()
    {
        await Element.FocusAsync();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        ParentDropdownMenu.RegisterItem(this);
    }

    private async Task ClickHandler(MouseEventArgs args)
    {
        if (IsDisabled || IsAriaDisabled)
        {
            return;
        }

        await OnClick.InvokeAsync(args);
        await ParentDropdown.Select(this);
    }

    private async Task KeydownHandler(KeyboardEventArgs args)
    {
        if (IsDisabled || IsAriaDisabled)
        {
            return;
        }

        // Detected key press on this item, notify the menu parent so that the appropriate item can be focused
        if (args.Key == Keys.ArrowUp)
        {
            await ParentDropdownMenu.ChildKeyHandler(this, KeyhandlerDirection.Up);
        }
        else if (args.Key == Keys.ArrowDown)
        {
            await ParentDropdownMenu.ChildKeyHandler(this, KeyhandlerDirection.Down);
        }
        else if (args.Key is Keys.Enter or Keys.Space)
        {
            await ClickHandler(null);
            if (EnterTriggersArrowDown)
            {
                await ParentDropdownMenu.ChildKeyHandler(this, KeyhandlerDirection.Down);
            }
        }
    }

    private Task KeypressHandler(KeyboardEventArgs args)
    {
        return Task.CompletedTask;
    }
}
