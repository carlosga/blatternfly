namespace Blatternfly.Components;

public partial class DropdownMenu : ComponentBase
{
    private ElementReference Element { get; set; }

    /// <summary>
    /// Parent Dropdown component.
    /// </summary>
    [CascadingParameter]
    private Dropdown Parent { get; set; }

    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Flag to indicate if menu is opened.
    /// </summary>
    [Parameter]
    public bool IsOpen { get; set; }

    /// <summary>
    /// Flag to indicate if menu should be opened on enter.
    /// </summary>
    [Parameter]
    public bool OpenedOnEnter { get; set; }

    /// <summary>
    /// Flag to indicate if the first dropdown item should gain initial focus, set false when adding
    /// a specific auto-focus item (like a current selection) otherwise leave as true.
    /// </summary>
    [Parameter]
    public bool AutoFocus { get; set; } = true;

    /// <summary>
    /// Indicates where menu will be aligned horizontally.
    /// </summary>
    [Parameter]
    public DropdownPosition Position { get; set; } = DropdownPosition.Left;

    /// <summary>
    /// Indicates how the menu will align at screen size breakpoints. Default alignment is set via the position property.
    /// </summary>
    [Parameter]
    public AlignmentModifiers Alignments { get; set; }

    /// <summary>
    /// Flag to indicate if menu is grouped.
    /// </summary>
    [Parameter]
    public bool IsGrouped { get; set; }

    private string CssClass => new CssBuilder()
        .AddClass("pf-c-dropdown__menu", string.IsNullOrEmpty(Parent?.MenuClass))
        .AddClass(Parent.MenuClass     , !string.IsNullOrEmpty(Parent?.MenuClass))
        .AddClass("pf-m-align-right"   , Position is DropdownPosition.Right)
        .AddClass(Alignments?.CssClass())
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private  bool   IsHidden { get => !IsOpen; }
    internal string MenuId   { get => AdditionalAttributes.GetPropertyValue(HtmlAttributes.Id); }

    private List<DropdownItem> _items = new();

    internal void RegisterItem(DropdownItem item)
    {
        if (!_items.Contains(item))
        {
            _items.Add(item);
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            if (IsOpen && OpenedOnEnter)
            {
                // TODO: Workaround for https://github.com/dotnet/aspnetcore/issues/30070
                await Task.Yield();

                if (AutoFocus)
                {
                    await FocusFirstRefAsync();
                }
                else
                {
                    await FocusFirstAutoFocusItemAsync();
                }
            }
        }
    }

    private async Task FocusFirstRefAsync()
    {
        if (_items is not null && _items.Count > 0)
        {
            var item = _items[0];
            await item.FocusAsync();
        }
    }

    private async Task FocusFirstAutoFocusItemAsync()
    {
        if (_items is not null && _items.Count > 0)
        {
            var item = _items.FirstOrDefault(x => x.AutoFocus);
            if (item is not null)
            {
                await item.FocusAsync();
            }
        }
    }

    internal async Task ChildKeyHandler(DropdownItem item, KeyhandlerDirection direction)
    {
        if (_items is null || _items.Count == 0)
        {
            return;
        }
        var index     = _items.IndexOf(item);
        var nextIndex = _items.IndexOf(item);
        if (direction == KeyhandlerDirection.Up)
        {
            if (index == 0)
            {
                // loop back to end
                nextIndex = _items.Count - 1;
            }
            else
            {
                nextIndex = index - 1;
            }
        }
        else if (direction == KeyhandlerDirection.Down)
        {
            if (index == _items.Count - 1)
            {
                // loop back to beginning
                nextIndex = 0;
            }
            else
            {
                nextIndex = index + 1;
            }
        }

        var nextItem = _items[nextIndex];
        if (nextItem.IsDisabled || nextItem.IsAriaDisabled)
        {
            await ChildKeyHandler(nextItem, direction);
        }
        else
        {
           await _items[nextIndex].FocusAsync();
        }
    }
}