namespace Blatternfly.Components;

public partial class SelectOption : ComponentBase
{
    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }

    [CascadingParameter] private Select Parent { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Description of the item for single and both typeahead select variants.</summary>
    [Parameter] public RenderFragment Description { get; set; }

    /// <summary>Number of items matching the option.</summary>
    [Parameter] public int ItemCount { get; set; }

    /// <summary>@hide Internal index of the option.</summary>
    [Parameter] public int Index { get; set; }

    /// <summary>Indicates which component will be used as select item.</summary>
    [Parameter] public string Component { get; set; }

    /// <summary>The value for the option.</summary>
    [Parameter] public string Value { get; set; }

    /// <summary>The text for the option.</summary>
    [Parameter] public string Text { get; set; }

    /// <summary>Flag indicating if the option is disabled.</summary>
    [Parameter] public bool IsDisabled { get; set; }

    /// <summary>Flag indicating if the option acts as a placeholder.</summary>
    [Parameter] public bool IsPlaceholder { get; set; }

    /// <summary>Flag indicating if the option acts as a "no results" indicator.</summary>
    [Parameter] public bool IsNoResultsOption { get; set; }

    /// <summary>@hide Internal flag indicating if the option is selected.</summary>
    [Parameter] public bool IsSelected { get; set; }

    /// <summary>Flag forcing the focused state.</summary>
    [Parameter] public bool IsFocused { get; set; }

    // <summary>@hide Internal callback for keyboard navigation.</summary>
    // keyHandler?: (index: number, innerIndex: number, position: string) => void;

    /// <summary>Optional callback for click event.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    /// <summary>Id of the checkbox input.</summary>
    [Parameter] public string InputId { get; set; }

    /// <summary>@hide Internal Flag indicating if the option is favorited.</summary>
    [Parameter] public bool IsFavorite { get; set; }

    /// <summary>Aria label text for favoritable button when favorited.</summary>
    [Parameter] public bool AriaIsFavoriteLabel { get; set; }

    /// <summary>Aria label text for favoritable button when not favorited.</summary>
    [Parameter] public bool AriaIsNotFavoriteLabel { get; set; }

    /// <summary>ID of the item. Required for tracking favorites.</summary>
    [Parameter] public string Id { get; set; }

    /// <summary>@hide Internal flag to apply the load styling to view more option.</summary>
    [Parameter] public bool IsLoad { get; set; }

    /// <summary>@hide Internal flag to apply the loading styling to spinner.</summary>
    [Parameter] public bool IsLoading { get; set; }

    private string ListItemCssClass => new CssBuilder()
        .AddClass("pf-c-select__list-item"    , IsLoading)
        .AddClass("pf-c-select__menu-wrapper" , !IsLoad && !IsLoading)
        .AddClass("pf-m-favorite"             , IsFavorite)
        .AddClass("pf-m-focus"                , IsFocused)
        .AddClass("pf-m-loading"              , IsLoading)
        .Build();

    private string MenuItemCssClass => new CssBuilder("pf-c-select__menu-item")
        .AddClass("pf-m-load"        , IsLoad)
        .AddClass("pf-m-selected"    , IsSelected)
        .AddClass("pf-m-disabled"    , IsDisabled)
        .AddClass("pf-m-description" , Description is not null)
        .AddClass("pf-m-link"        , IsFavorite)
        .Build();

    private string GeneratedId       { get; set; }
    private string FavoriteAriaLabel { get => IsFavorite ? AriaIsFavoriteLabel.ToString() : AriaIsNotFavoriteLabel.ToString(); }
    private string AriaSelected      { get => IsSelected ? "true" : null; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        GeneratedId = !string.IsNullOrEmpty(Id) ? Id : ComponentIdGenerator.Generate("select-option");
    }

    private async Task OnItemClick(MouseEventArgs args)
    {
        if (IsLoad)
        {
            await OnClick.InvokeAsync(args);
        }
        else if (!IsDisabled && !IsLoading)
        {
            await OnClick.InvokeAsync(args);
            await Parent.SelectOption(this);
            await Parent.Close();
        }
    }

    private Task OnFavorite(MouseEventArgs args)
    {
        return Task.CompletedTask;
        // OnFavorite(GeneratedId.Replace('favorite-', ''), isFavorite);
    }

    private Task OnFavoriteKeyDown(KeyboardEventArgs args)
    {
        return Task.CompletedTask;
        // await OnKeyDown(event, 1, () => onFavorite(generatedId.replace('favorite-', '')));
    }

    private Task OnKeyDown(KeyboardEventArgs args)
    {
        return Task.CompletedTask;
    }
}