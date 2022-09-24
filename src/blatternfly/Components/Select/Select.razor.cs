namespace Blatternfly.Components;

public partial class Select : ComponentBase
{
    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Indicates where menu will be aligned horizontally.</summary>
    [Parameter] public SelectPosition Position { get; set; } = SelectPosition.Left;

    /// <summary>Flag specifying which direction the Select menu expands.</summary>
    [Parameter] public SelectDirection Direction { get; set; } = SelectDirection.Down;

    /// <summary>Flag to indicate if select is open.</summary>
    [Parameter] public bool IsOpen { get; set; }

    /// <summary>Flag to indicate if select options are grouped.</summary>
    [Parameter] public bool IsGrouped { get; set; }

    /// <summary>Display the toggle with no border or background.</summary>
    [Parameter] public bool IsPlain { get; set; }

    /// <summary>Flag to indicate if select is disabled.</summary>
    [Parameter] public bool IsDisabled { get; set; }

    /// <summary>Flag indicating if placeholder styles should be applied.</summary>
    [Parameter] public bool HasPlaceholderStyle { get; set;  }

    /// <summary>
    /// Value to indicate if the select is modified to show that validation state.
    /// If set to success, select will be modified to indicate valid state.
    /// If set to error, select will be modified to indicate error state.
    /// If set to warning, select will be modified to indicate warning state.
    /// </summary>
    [Parameter] public ValidatedOptions? Validated { get; set; }

    /// <summary>@beta Loading variant to display either the spinner or the view more text button.</summary>
    [Parameter] public RenderFragment LoadingVariant { get; set; }

    /// <summary>Title text of Select.</summary>
    [Parameter] public string PlaceholderText { get; set; }

    /// <summary>Array of selected items for multi select variants.</summary>
    [Parameter] public string Selections { get; set;}

    /// <summary>Id for select toggle element.</summary>
    [Parameter] public string ToggleId { get; set; }

    /// <summary>Adds accessible text to Select.</summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>Id of label for the Select aria-labelledby.</summary>
    [Parameter] public string AriaLabelledBy { get; set; }

    /// <summary>Id of div for the select aria-labelledby.</summary>
    [Parameter] public string AriaDescribedBy { get; set; }

    /// <summary>Flag indicating if the select is an invalid state.</summary>
    [Parameter] public bool AriaInvalid { get; set; }

    /// <summary>Label for clear selection button of type ahead select variants.</summary>
    [Parameter] public string ClearSelectionsAriaLabel { get; set; }

    /// <summary>Label for toggle of type ahead select variants.</summary>
    [Parameter] public string ToggleAriaLabel { get; set; }

    /// <summary>Callback for selection behavior.</summary>
    [Parameter] public EventCallback<SelectOption> OnSelect { get; set; }

    /// <summary>Callback for toggle button behavior.</summary>
    [Parameter] public EventCallback<bool> OnToggle { get; set; }

    /// <summary>Callback for typeahead clear button.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClear { get; set; }

    /// <summary>Variant of rendered Select.</summary>
    [Parameter] public SelectVariant Variant { get; set; } = SelectVariant.Single;

    /// <summary>Width of the select container as a number of px or string percentage.</summary>
    [Parameter] public string Width { get; set; }

    /// <summary>Max height of the select container as a number of px or string percentage.</summary>
    [Parameter] public string MaxHeight { get; set; }

    /// <summary>Icon element to render inside the select toggle.</summary>
    [Parameter] public RenderFragment ToggleIcon { get; set; }

    /// <summary>
    /// Custom content to render in the select menu.
    /// If this prop is defined, the variant prop will be ignored and the select will render with a single select toggle.
    /// </summary>
    [Parameter] public RenderFragment CustomContent { get; set; }

    /// <summary>Content rendered in the footer of the select menu.</summary>
    [Parameter] public RenderFragment Footer { get; set; }

    /// <summary></summary>
    [Parameter] public bool OpenedOnEnter { get; set; }

    private string CssStyle => new StyleBuilder()
        .AddStyle("width", Width, !string.IsNullOrEmpty(Width))
        .Build();

    private string CssClass => new CssBuilder("pf-c-select")
        .AddClass("pf-m-expanded", IsOpen)
        .AddClass("pf-m-success" , Validated is ValidatedOptions.Success)
        .AddClass("pf-m-warning" , Validated is ValidatedOptions.Warning)
        .AddClass("pf-m-invalid" , Validated is ValidatedOptions.Error)
        .AddClass("pf-m-top"     , Direction is SelectDirection.Up)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private SelectOption SelectedOption { get; set; }

    private bool   FocusFirstOption        { get; set; }
    private bool   HasOnClear              { get => OnClear.HasDelegate; }
    private bool   HasFooter               { get => Footer is not null; }
    private bool   HasAnySelections        { get => !string.IsNullOrEmpty(Selections); }
    private string MenuAppendTo            { get; set; } = "inline";
    private string SelectToggleId          { get; set; }
    private string InternalAriaDescribedBy { get => Validated.HasValue ? AriaDescribedBy : null; }
    private string InternalAriaInvalid     { get => Validated.HasValue ? (AriaInvalid ? "true" : "false") : null; }
    private string InternalAriaLabelledBy  { get => $"{AriaLabelledBy} {SelectToggleId}"; }
    private bool   IsSelectedPlaceholder   { get => SelectedOption is not null && SelectedOption.IsPlaceholder; }
    private bool   ToogleHasPlaceholderStyle
    {
        get => HasPlaceholderStyle && ((Selections is not null && Selections.Length > 0) || IsSelectedPlaceholder);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        SelectToggleId = ToggleId ?? ComponentIdGenerator.Generate("pf-select-toggle-id");
    }

    internal async Task SelectOption(SelectOption option)
    {
        SelectedOption = option;
        Selections     = option.Value;
        await OnSelect.InvokeAsync(option);
    }

    internal async Task Close()
    {
        await CloseHandler();
    }

    private Task CloseHandler()
    {
        FocusFirstOption = false;
        return Task.CompletedTask;
    }

    private void EnterHandler()
    {
        FocusFirstOption = true;
    }

    private async Task ToggleHandler(bool isExpanded)
    {
        await OnToggle.InvokeAsync(isExpanded);
    }

    private async Task ClearHandler(MouseEventArgs args)
    {
        ClearSelection();
        await OnClear.InvokeAsync();
    }

    private async Task OnClearKeyDown(KeyboardEventArgs args)
    {
        if (args.Key == Keys.Enter)
        {
            ClearSelection();
            await OnClear.InvokeAsync();
        }
    }

    private void HandleMenuKeys(int index, int innerIndex, string position)
    {
        // TODO: utils keyHandler
        // keyHandler(index, innerIndex, position, this.refCollection, this.refCollection);
    }

    private void ClearSelection()
    {
        Selections = null;
    }
}