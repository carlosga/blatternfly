namespace Blatternfly.Components;

/// <summary> The main pagination component.</summary>
public partial class Pagination : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Indicate whether to show last full page of results when user selects perPage value greater than remaining rows</summary>
    [Parameter] public bool DefaultToFullPage { get; set; }

    /// <summary>Direction of dropdown context menu.</summary>
    [Parameter] public DropdownDirection? DropDirection { get; set; }

    /// <summary>Page we start at.</summary>
    [Parameter] public int FirstPage { get; set; } = 1;

    /// <summary>Flag indicating if pagination is compact</summary>
    [Parameter] public bool IsCompact { get; set; }

    /// <summary>Flag indicating if pagination is disabled</summary>
    [Parameter] public bool IsDisabled { get; set; }

    /// <summary>Flag indicating if pagination should not be sticky on mobile</summary>
    [Parameter] public bool IsStatic { get; set; }

    /// <summary>Flag indicating if pagination should stick to its position (based on variant)</summary>
    [Parameter] public bool IsSticky { get; set; }

    /// <summary>Total number of items.</summary>
    [Parameter] public int? ItemCount { get; set; }

    /// <summary>Last index of items on current page.</summary>
    [Parameter] public int ItemsEnd { get; set; }

    /// <summary>First index of items on current page.</summary>
    [Parameter] public int ItemsStart { get; set; }

    /// <summary>Start index of rows to display, used in place of providing page</summary>
    [Parameter] public int Offset { get; set; }

    /// <summary>Id added to the options toggle.</summary>
    [Parameter] public string OptionsToggleId { get; set; }

    /// <summary>Current page number.</summary>
    [Parameter] public int Page { get; set; }

    /// <summary>Number of items per page.</summary>
    [Parameter] public int PerPage { get; set; } = DefaultPerPageOptions[0].Value;

    /// <summary>
    /// Component to be used for wrapping the toggle contents.
    /// Use 'button' when you want all of the toggle text to be clickable.
    /// </summary>
    [Parameter] public PerPageComponents PerPageComponent { get; set; } = PerPageComponents.div;

    /// <summary>Select from options to number of items per page.</summary>
    [Parameter] public PerPageOptions[] PerPageOptions { get; set; } = DefaultPerPageOptions;

    /// <summary>Function called when user clicks on navigate to first page.</summary>
    [Parameter] public EventCallback<int> OnFirstClick { get; set; }

    /// <summary>Function called when user clicks on navigate to last page.</summary>
    [Parameter] public EventCallback<int> OnLastClick { get; set; }

    /// <summary>Function called when user clicks on navigate to next page.</summary>
    [Parameter] public EventCallback<int> OnNextClick { get; set; }

    /// <summary>Function called when user inputs page number.</summary>
    [Parameter] public EventCallback<int> OnPageInput { get; set; }

    /// <summary>Function called when user selects number of items per page.</summary>
    [Parameter] public EventCallback<PerPageSelectEventArgs> OnPerPageSelect { get; set; }

    /// <summary>Function called when user clicks on navigate to previous page.</summary>
    [Parameter] public EventCallback<int> OnPreviousClick { get; set; }

    /// <summary>Function called when user sets page.</summary>
    [Parameter] public EventCallback<SetPageEventArgs> OnSetPage { get; set; }

    /// <summary>Object with titles to display in pagination.</summary>
    [Parameter] public PaginationTitles Titles { get;  set; } = new();

    /// <summary>This will be shown in pagination toggle span. You can use firstIndex, lastIndex, itemCount, itemsTitle, ofWord props.</summary>
    [Parameter] public RenderFragment<ToggleTemplateProps> ToggleTemplate { get; set; }

    /// <summary>Position where pagination is rendered.</summary>
    [Parameter] public PaginationVariant Variant { get; set; } = PaginationVariant.Top;

    /// <summary>ID to identify widget on page.</summary>
    [Parameter] public string WidgetId { get; set; } = "pagination-options-menu";

    private ToggleTemplateProps CustomToggleTemplateProps
        => new (FirstIndex, LastIndex, ItemCount, Titles?.Items, Titles?.OfWord);

    private string CssClass => new CssBuilder("pf-c-pagination")
        .AddClass("pf-m-bottom" , Variant is PaginationVariant.Bottom)
        .AddClass("pf-m-compact", IsCompact)
        .AddClass("pf-m-static" , IsStatic)
        .AddClass("pf-m-sticky" , IsSticky)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private static readonly PerPageOptions[] DefaultPerPageOptions =
    {
        new() { Title =  "10", Value =  10 },
        new() { Title =  "20", Value =  20 },
        new() { Title =  "50", Value =  50 },
        new() { Title = "100", Value = 100 }
    };

    private string InternalId  { get => AdditionalAttributes.GetPropertyValue(HtmlElement.Id); }
    private string ComponentId { get; set; }
    private string InputStyle  { get; set; }
    private int    FirstIndex  { get; set; }
    private int    LastIndex   { get; set; }
    private int    LastPage    { get; set; }

    private DropdownDirection OptionsMenuDirection
    {
        get => DropDirection ?? (Variant is PaginationVariant.Bottom && !IsStatic
            ? DropdownDirection.Up
                : DropdownDirection.Down);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        ComponentId = !string.IsNullOrEmpty(InternalId) ? InternalId : ComponentIdGenerator.Generate(WidgetId);
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        var page = Page;

        if (page == 0 && Offset > 0)
        {
            page = (PerPage == 0) ? 0 : (int)Math.Ceiling(Offset / (double)PerPage);
        }
        if (page == 0 && !ItemCount.HasValue)
        {
            page = 1;
        }

        LastPage   = GetLastPage();
        FirstIndex = (page - 1) * PerPage + 1;
        LastIndex  = page * PerPage;

        if (ItemCount.HasValue)
        {
            FirstIndex = ItemCount.Value <= 0 ? 0 : (page - 1) * PerPage + 1;
            if (FirstIndex < 0)
            {
                FirstIndex += PerPage;
            }

            if (page < FirstPage && ItemCount.Value > 0)
            {
                page = FirstPage;
            }
            else if (page > LastPage)
            {
                page = LastPage;
            }

            if (ItemCount.Value >= 0)
            {
                LastIndex = page == LastPage || ItemCount.Value == 0 ? ItemCount.Value : page * PerPage;
            }
        }

        Page = page;
    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);

        HandleInputWidth(GetLastPage());
    }

    private int GetLastPage()
    {
        // when itemCount is not known let's set lastPage as page+1 as we don't know the total count
        return ItemCount.HasValue
            ? (PerPage == 0) ? 0 : (int)Math.Ceiling(ItemCount.GetValueOrDefault() / (double)PerPage)
                : Page + 1;
    }

    private void HandleInputWidth(int lastPage)
    {
        var len        = lastPage.ToString().Length;
        var widthChars = len >= 3 ? len : 2;
        var inputStyle = $"--pf-c-pagination__nav-page-select--c-form-control--width-chars:{widthChars}";

        if (inputStyle != InputStyle)
        {
            InputStyle = inputStyle;
            StateHasChanged();
        }
    }
}