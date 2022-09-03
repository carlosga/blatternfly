namespace Blatternfly.Components;

public partial class Dropdown : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Array of DropdownItem nodes that will be rendered in the dropdown Menu list.
    /// </summary>
    [Parameter]
    public RenderFragment DropdownItems { get; set; }

    /// <summary>
    /// Flag to indicate if menu is opened.
    /// </summary>
    [Parameter]
    public bool IsOpen { get;  set; }

    /// <summary>
    /// Display the toggle with no border or background.
    /// </summary>
    [Parameter]
    public bool IsPlain { get; set; }

    /// <summary>
    /// Display the toggle in text only mode.
    /// </summary>
    [Parameter]
    public bool IsText { get; set; }

    /// <summary>
    /// Flag indicating that the dropdown should expand to full height.
    /// </summary>
    [Parameter]
    public bool IsFullHeight { get; set; }

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
    /// Display menu above or below dropdown toggle.
    /// </summary>
    [Parameter]
    public DropdownDirection Direction { get; set; } = DropdownDirection.Down;

    /// <summary>
    /// Flag to indicate if dropdown has groups.
    /// </summary>
    [Parameter]
    public bool IsGrouped { get; set; }

    /// <summary>
    /// Toggle for the dropdown, examples: <DropdownToggle> or <DropdownToggleCheckbox>
    /// </summary>
    [Parameter]
    public RenderFragment Toggle { get; set; }

    /// <summary>
    /// Flag to indicate if the first dropdown item should gain initial focus, set false when adding
    /// a specific auto-focus item (like a current selection) otherwise leave as true
    /// </summary>
    [Parameter]
    public bool AutoFocus { get; set; } = true;

    /// <summary>
    /// Function callback called when user selects item.
    /// </summary>
    [Parameter]
    public EventCallback<DropdownItem> OnSelect { get; set; }

    /// <summary>
    /// Flag for indicating that the dropdown menu should automatically flip vertically when
    /// it reaches the boundary. This prop can only be used when the dropdown component is not
    /// appended inline.
    /// </summary>
    [Parameter]
    public bool IsFlipEnabled { get; set; }

    /// <summary>
    /// </summary>
    [Parameter]
    public bool OpenedOnEnter { get; set; }

    /// <summary>
    /// </summary>
    [Parameter]
    public string BaseClass { get; set; }

    /// <summary>
    /// </summary>
    [Parameter]
    public string MenuClass { get; set; }

    /// <summary>
    /// </summary>
    [Parameter]
    public string ItemClass{ get; set; }

    internal string AriaHasPopup { get => DropdownItems is not null ? "true" : null; }
    internal DropdownMenu DropdownMenu { get; private set; }

    private string CssClass => new CssBuilder(DropDownClass)
        .AddClass("pf-m-expanded"   , IsOpen)
        .AddClass("pf-m-top"        , Direction is DropdownDirection.Up)
        .AddClass("pf-m-align-right", Position  is DropdownPosition.Right)
        .AddClass("pf-m-full-height", IsFullHeight)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string DropdownMenuId    { get; set; }
    private bool   AutoFocusEnabled  { get => OpenedOnEnter && AutoFocus; }
    private string DropDownClass     { get => !string.IsNullOrEmpty(BaseClass) ? BaseClass : "pf-c-dropdown"; }
    private string AriaLabelledBy    { get => _toggle?.ToggleId; }
    private string DropdownMenuStyle => new StyleBuilder()
        .AddStyle("position" , "revert"     , IsFlipEnabled)
        .AddStyle("min-width", "min-content", IsFlipEnabled)
        .Build();

    private Toggle _toggle;

    internal void RegisterToggle(Toggle toggle)
    {
        _toggle = toggle;
        DropdownMenuId = $"pf-dropdown-menu__{_toggle.ToggleId}";
        StateHasChanged();
    }

    internal void OnToggle(bool isOpen)
    {
        OpenedOnEnter = false;
        IsOpen        = isOpen;
        StateHasChanged();
    }

    internal void OnEnter()
    {
        OpenedOnEnter = !OpenedOnEnter;
        IsOpen        = !IsOpen;
        StateHasChanged();
    }

    internal async Task Select(DropdownItem item)
    {
        await OnSelect.InvokeAsync(item);
        if (_toggle is not null)
        {
            await _toggle.CloseAsync();
        }
    }

    private async Task OnEscPress(KeyboardEventArgs args)
    {
        if (IsOpen && (args.Key is Keys.Escape or Keys.Tab))
        {
            await _toggle.CloseAsync();
            await _toggle.FocusAsync();
        }
    }
}