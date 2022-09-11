namespace Blatternfly.Components;

public partial class AdvancedSearchMenu : ComponentBase, IDisposable
{
    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }
    [Inject] private IWindowObserver WindowObserver { get; set; }

    [CascadingParameter] public SearchInput Parent { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Value of the search input.</summary>
    [Parameter] public string Value { get; set; }

    /// <summary>Function which builds an attribute-value map by parsing the value in the search input.</summary>
    [Parameter] public Func<IDictionary<string, string>> GetAttrValueMap { get; set; }

    /// <summary>A callback for when the search button clicked changes.</summary>
    [Parameter] public EventCallback<(string, IDictionary<string, string>)> OnSearch { get; set; }

    /// <summary>A callback for when the user clicks the clear button.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClear { get; set; }

    /// <summary>A callback for when the input value changes.</summary>
    [Parameter] public EventCallback<ChangeEventArgs> OnChange { get; set; }

    /// <summary>Function called to toggle the advanced search menu.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnToggleAdvancedMenu { get; set; }

    /// <summary>Flag for toggling the open/close state of the advanced search menu.</summary>
    [Parameter] public bool IsSearchMenuOpen { get; set; }

    /// <summary>Label for the buttons which reset the advanced search form and clear the search input.</summary>
    [Parameter] public string ResetButtonLabel { get; set; } = "Reset";

    /// <summary>Label for the buttons which called the onSearch event handler.</summary>
    [Parameter] public string SubmitSearchButtonLabel { get; set; } = "Search";

    /// <summary>Array of attribute values used for dynamically generated advanced search.</summary>
    [Parameter] public SearchAttribute[] Attributes { get; set; } = Array.Empty<SearchAttribute>();

    /// <summary>Additional elements added after the attributes in the form.</summary>
    /// <summary>The new form elements can be wrapped in a FormGroup component for automatic formatting.</summary>
    [Parameter] public RenderFragment FormAdditionalItems { get; set; }

    /// <summary>Attribute label for strings unassociated with one of the provided listed attributes.</summary>
    [Parameter] public string HasWordsAttrLabel { get; set; } = "Has words";

    /// <summary>Delimiter in the query string for pairing attributes with search values.</summary>
    /// <summary>Required whenever attributes are passed as props.</summary>
    [Parameter] public string AdvancedSearchDelimiter { get; set; }

    private string CssClass => new CssBuilder()
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private IDisposable _windowClickSubscription;
    private IDisposable _windowKeydownSubscription;

    public void Dispose()
    {
        _windowClickSubscription?.Dispose();
        _windowKeydownSubscription?.Dispose();
    }

    private TextInput FirstAttrRef   { get; set; }
    private string RandomId          { get; set; }
    private bool PutFocusBackOnInput { get; set; }

    private IEnumerable<SearchAttribute> InternalAttributes
    {
        get
        {
            foreach (var attribute in Attributes)
            {
                yield return attribute;
            }

            yield return new SearchAttribute
            {
                Attribute = "haswords",
                Display   = HasWordsAttrLabel
            };
        }
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        RandomId                   = ComponentIdGenerator.Generate();
        _windowClickSubscription   = WindowObserver.OnClick.Subscribe(async e => await OnDocClick(e));
        _windowKeydownSubscription = WindowObserver.OnKeydown.Subscribe(async e => await OnEscPress(e));
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (IsSearchMenuOpen && !PutFocusBackOnInput)
        {
            await FirstAttrRef.Element.FocusAsync();
            PutFocusBackOnInput = true;
        }
        else if (!IsSearchMenuOpen && PutFocusBackOnInput)
        {
            PutFocusBackOnInput = false;
            if (Parent is not null)
            {
                await Parent.FocusAsync();
            }
        }
    }

    private async Task OnDocClick(MouseEvent e)
    {
        var clickedWithinSearchInput = e.ComposedPath?.Any(x => x == Parent?.Id);
        if (IsSearchMenuOpen && !clickedWithinSearchInput.GetValueOrDefault())
        {
            await OnToggleAdvancedMenu.InvokeAsync(null);

            if (Parent is not null)
            {
                await Parent.FocusAsync();
            }
        }
    }

    private async Task OnEscPress(KeyboardEvent e)
    {
        if (IsSearchMenuOpen && e.Key == Keys.Escape)
        {
            await OnToggleAdvancedMenu.InvokeAsync(null);

            if (Parent is not null)
            {
                await Parent.FocusAsync();
            }
        }
    }

    private string FormatFieldId(SearchAttribute attribute)
        => $"{attribute.Attribute}_{Array.IndexOf(Attributes, attribute)}";

    private string GetValue(SearchAttribute attribute) => GetValue(attribute.Attribute);

    private string GetValue(string attribute)
    {
        var map = GetAttrValueMap();
        return map.ContainsKey(attribute) ? map[attribute] : string.Empty;
    }

    private async Task HandleValueChange(SearchAttribute attribute, string newValue)
        => await HandleValueChange(attribute.Attribute, newValue);

    private async Task HandleValueChange(string attribute, string newValue)
    {
        var newMap = GetAttrValueMap();
        newMap[attribute] = newValue;
        var updatedValue = string.Empty;

        foreach (var (key, value) in newMap)
        {
            if (!string.IsNullOrEmpty(value?.Trim()))
            {
                updatedValue = (key != "haswords")
                    ? $"{updatedValue} {key}{AdvancedSearchDelimiter}{value}"
                        : $"{updatedValue} {value}";
            }
        }

        updatedValue = System.Text.RegularExpressions.Regex.Replace(updatedValue, "\\s+", string.Empty);

        if (OnChange.HasDelegate)
        {
            await OnChange.InvokeAsync(new ChangeEventArgs { Value = updatedValue });
        }
    }

    private async Task OnSearchHandler(MouseEventArgs args)
    {
        // event.preventDefault();

        if (OnSearch.HasDelegate)
        {
            await OnSearch.InvokeAsync((Value, GetAttrValueMap()));
        }
        if (IsSearchMenuOpen)
        {
           await OnToggleAdvancedMenu.InvokeAsync(args);
        }
    }
}