namespace Blatternfly.Components;

public partial class SearchInput : ComponentBase
{
    public ElementReference Element { get; protected set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Value of the search input.</summary>
    [Parameter] public string Value { get; set; }

    /// <summary>Flag indicating if search input is disabled.</summary>
    [Parameter] public bool IsDisabled { get; set; }

    /// <summary>An accessible label for the search input.</summary>
    [Parameter] public string AriaLabel { get; set; } = "Search input";

    /// <summary>placeholder text of the search input.</summary>
    [Parameter] public string Placeholder { get; set; }

    /// <summary>A callback for when the input value changes.</summary>
    [Parameter] public EventCallback<ChangeEventArgs> OnChange { get; set; }

    /// <summary>A suggestion for autocompleting.</summary>
    [Parameter] public string Hint { get; set; }

    /// <summary>Flag to indicate if the search input should be expandable/collapsible.</summary>
    [Parameter] public bool ExpandableInput { get; set; }

    /// <summary>A callback for when the search button clicked changes.</summary>
    [Parameter] public EventCallback<(string, IDictionary<string, string>)> OnSearch { get; set; }

    /// <summary>A callback for when the user clicks the clear button.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClear { get; set; }

    /// <summary>Label for the buttons which reset the advanced search form and clear the search input.</summary>
    [Parameter] public string ResetButtonLabel { get; set; } = "Reset";

    /// <summary>Label for the buttons which called the onSearch event handler.</summary>
    [Parameter] public string SubmitSearchButtonLabel { get; set; } = "Search";

    /// <summary>A callback for when the open advanced search button is clicked.</summary>
    [Parameter] public EventCallback<bool> OnToggleAdvancedSearch { get; set; }

    /// <summary>A flag for controlling the open state of a custom advanced search implementation.</summary>
    [Parameter] public bool IsAdvancedSearchOpen { get; set; }

    /// <summary>Label for the button which opens the advanced search form menu.</summary>
    [Parameter] public string OpenMenuButtonAriaLabel { get; set; } = "Open advanced search";

    /// <summary>Label for the button to navigate to previous result.</summary>
    [Parameter] public string PreviousNavigationButtonAriaLabel { get; set; } = "Previous";

    /// <summary>Flag indicating if the previous navigation button is disabled.</summary>
    [Parameter] public bool IsPreviousNavigationButtonDisabled { get; set; }

    /// <summary>Label for the button to navigate to next result.</summary>
    [Parameter] public string NextNavigationButtonAriaLabel { get; set; } = "Next";

    /// <summary>Flag indicating if the next navigation button is disabled.</summary>
    [Parameter] public bool IsNextNavigationButtonDisabled { get; set; }

    /// <summary>Function called when user clicks to navigate to next result.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnNextClick { get; set; }

    /// <summary>Function called when user clicks to navigate to previous result.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnPreviousClick { get; set; }

    /// <summary>
    /// The number of search results returned. Either a total number of results,
    /// or a string representing the current result over the total number of results. i.e. "1 / 5".
    /// </summary>
    [Parameter] public string ResultsCount { get; set; }

    /// <summary>Array of attribute values used for dynamically generated advanced search.</summary>
    [Parameter] public SearchAttribute[] Attributes { get; set; } = Array.Empty<SearchAttribute>();

    /// <summary>
    /// Additional elements added after the attributes in the form.
    /// The new form elements can be wrapped in a FormGroup component for automatic formatting.
    /// </summary>
    [Parameter] public RenderFragment FormAdditionalItems { get; set; }

    /// <summary>Attribute label for strings unassociated with one of the provided listed attributes.</summary>
    [Parameter] public string HasWordsAttrLabel { get; set; } = "Has words";

    /// <summary>
    /// Delimiter in the query string for pairing attributes with search values.
    /// Required whenever attributes are passed as props.
    /// </summary>
    [Parameter] public string AdvancedSearchDelimiter { get; set; }

    /// <summary>Flag to indicate if the search input is expanded.</summary>
    [Parameter] public bool IsExpanded { get; set; }

    /// <summary>Callback function to toggle the expandable search input.</summary>
    [Parameter] public EventCallback<bool> OnToggleExpand { get; set; }

    /// <summary>An accessible label for the expandable search input toggle.</summary>
    [Parameter] public string ToggleAriaLabel { get; set; }

    private string CssClass => new CssBuilder("pf-c-search-input")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string ToggleAdvancedSearchCssClass => new CssBuilder()
        .AddClass("pf-m-expanded", IsSearchMenuOpen)
        .Build();

    internal string Id                       { get; set; }
    private  string InternalId               { get => AdditionalAttributes.GetPropertyValue(HtmlElement.Id); }
    private  bool   IsSearchMenuOpen         { get; set; }
    private  bool   IsSubmitButtonDisabled   { get => IsDisabled || string.IsNullOrEmpty(Value); }
    private  bool   IsNextButtonDisabled     { get => IsDisabled || IsNextNavigationButtonDisabled; }
    private  bool   IsPreviousButtonDisabled { get => IsDisabled || IsPreviousNavigationButtonDisabled; }
    private  bool   RenderUtilities
    {
        get => !string.IsNullOrEmpty(Value)
                && (!string.IsNullOrEmpty(ResultsCount)
                 || (OnNextClick.HasDelegate || OnPreviousClick.HasDelegate)
                  || (OnClear.HasDelegate && !ExpandableInput));
    }

    private bool FocusAfterExpandChange { get; set; }

    private TextInputGroupMain TextInputGroupMainRef { get; set; }
    private Button SearchInputExpandableToggleRef { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Id = InternalId ?? ComponentIdGenerator.Generate("pf-c-search-input");
    }

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        if (Attributes is { Length: > 0 } && string.IsNullOrEmpty(AdvancedSearchDelimiter))
        {
            throw new InvalidOperationException("SearchInput: An advancedSearchDelimiter prop is required when advanced search attributes are provided using the attributes prop");
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (FocusAfterExpandChange)
        {
            await SetFocusAfterExpandChange();
            FocusAfterExpandChange = false;
        }
    }

    private async Task OnEnter(KeyboardEventArgs args)
    {
        if (args.Key == Keys.Enter)
        {
            await OnSearchHandler(null);
        }
    }

    private async Task OnClearInput(MouseEventArgs args)
    {
        if (OnClear.HasDelegate)
        {
            await OnClear.InvokeAsync(args);
        }
        await FocusAsync();
    }

    private async Task OnToggle(MouseEventArgs _)
    {
        var isOpen = !IsSearchMenuOpen;
        IsSearchMenuOpen = isOpen;
        await OnToggleAdvancedSearch.InvokeAsync(isOpen);
    }

    private async Task OnChangeHandler(ChangeEventArgs args)
    {
        if (OnChange.HasDelegate)
        {
            await OnChange.InvokeAsync(args);
        }
        Value = args.Value as string;
    }

    private async Task OnSearchHandler(MouseEventArgs _)
    {
        if (OnSearch.HasDelegate)
        {
            var args = (Value, GetAttrValueMap());
            await OnSearch.InvokeAsync(args);
        }
        IsSearchMenuOpen = false;
    }

    private async Task OnExpandHandler()
    {
        Value = string.Empty;
        await OnToggleExpand.InvokeAsync(IsExpanded);
        FocusAfterExpandChange = true;
    }

    private async Task SetFocusAfterExpandChange()
    {
        if (!FocusAfterExpandChange)
        {
            return;
        }
        else if (IsExpanded)
        {
            await FocusAsync();
        }
        else if (SearchInputExpandableToggleRef is not null)
        {
            await SearchInputExpandableToggleRef.Element.FocusAsync();
        }
    }

    public async ValueTask FocusAsync()
    {
        if (TextInputGroupMainRef is not null)
        {
            await TextInputGroupMainRef.Element.FocusAsync();
        }
    }

    private IDictionary<string, string> GetAttrValueMap()
    {
        var attrs = new Dictionary<string, string>();
        var input = Value ?? string.Empty;
        var pairs = Value.Split(" ");
        foreach (var pair in pairs)
        {
            var splitPair = pair.Split(AdvancedSearchDelimiter);
            if (splitPair.Length == 2)
            {
                attrs.Add(splitPair[0], splitPair[1]);
            }
            else if (splitPair.Length == 1)
            {
                if (attrs.ContainsKey("haswords"))
                {
                    attrs["haswords"] = $"{attrs["haswords"]} {splitPair[0]}";
                }
                else
                {
                    attrs.Add("haswords", splitPair[0]);
                }
            }
        }
        return attrs;
    }
}