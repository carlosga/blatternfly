using Blatternfly.Interop;

namespace Blatternfly.Components;

public class DropdownItem : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// Parent Dropdown component
    [CascadingParameter] public Dropdown ParentDropdown { get; set; }

    /// Parent DropdownMenu component
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

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var disabled = IsDisabled || IsAriaDisabled ? "true" : null;

        builder.OpenElement(0, "li");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", ListItemCssClass);
        builder.AddAttribute(3, "role", Role);
        builder.AddAttribute(4, "onkeydown",  EventCallback.Factory.Create<KeyboardEventArgs>(this, KeydownHandler));
        builder.AddEventPreventDefaultAttribute(5, "onkeydown", true);
        builder.AddAttribute(6, "onkeypress",  EventCallback.Factory.Create<KeyboardEventArgs>(this, KeypressHandler));
        builder.AddEventPreventDefaultAttribute(7, "onkeypress", true);
        builder.AddAttribute(8, "onclick",  EventCallback.Factory.Create<MouseEventArgs>(this, ClickHandler));
        builder.AddEventPreventDefaultAttribute(9, "onclick", true);

        builder.OpenElement(10, Component);
        builder.AddAttribute(11, "id", ComponentId);
        builder.AddAttribute(12, "class", CssClass);
        builder.AddAttribute(13, "tabindex", IsDisabled || IsAriaDisabled ? -1 : TabIndex);

        if (Component == "a")
        {
            builder.AddAttribute(14, "aria-disabled", disabled);
        }
        else if (Component == "button")
        {
            builder.AddAttribute(15, "aria-disabled", disabled);
            builder.AddAttribute(16, "type", "button");
        }

        if (Description is not null)
        {
            builder.OpenElement(17, "div");
            builder.AddAttribute(18, "class", "pf-c-dropdown__menu-item-main");

            if (Icon is not null)
            {
                builder.OpenElement(19, "span");
                builder.AddAttribute(20, "class", "pf-c-dropdown__menu-item-icon");
                builder.AddContent(21, Icon);
                builder.CloseElement();
            }

            builder.AddContent(22, ChildContent);

            builder.CloseElement();

            builder.OpenElement(23, "div");
            builder.AddAttribute(24, "class", "pf-m-description");
            builder.AddContent(25, Description);
            builder.CloseElement();
        }
        else
        {
            if (Icon is not null)
            {
                builder.OpenElement(26, "span");
                builder.AddAttribute(27, "class", "pf-c-dropdown__menu-item-icon");
                builder.AddContent(28, Icon);
                builder.CloseElement();
            }

            builder.AddContent(29, ChildContent);
        }

        builder.AddElementReferenceCapture(30, __inputReference => Element = __inputReference);
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
