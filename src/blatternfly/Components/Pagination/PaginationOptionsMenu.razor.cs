namespace Blatternfly.Components;

public partial class PaginationOptionsMenu : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Id added to the title of the pagination options menu.</summary>
    [Parameter] public string WidgetId { get; set; }

    /// <summary>Id added to the options toggle.</summary>
    [Parameter] public string OptionsToggleId { get; set; }

    /// <summary>Flag indicating if pagination options menu is disabled.</summary>
    [Parameter] public bool IsDisabled { get; set; }

    /// <summary>Menu will open up or open down from the Options menu toggle.</summary>
    [Parameter] public DropdownDirection DropDirection { get; set; } = DropdownDirection.Down;

    /// <summary>Array of titles and values which will be the options on the Options Menu dropdown.</summary>
    [Parameter] public PerPageOptions[] PerPageOptions { get; set; }

    /// <summary>The title of the pagination options menu.</summary>
    [Parameter] public string ItemsPerPageTitle { get; set; } = "Items per page";

    /// <summary>Current page number.</summary>
    [Parameter] public int Page { get; set; }

    /// <summary>The suffix to be displayed after each option on the options menu dropdown.</summary>
    [Parameter] public string PerPageSuffix { get; set; } = "per page";

    /// <summary>The type or title of the items being paginated.</summary>
    [Parameter] public string ItemsTitle { get; set; } = "items";

    /// <summary>The text to be displayed on the options toggle.</summary>
    [Parameter] public string OptionsToggle { get; set; }

    /// <summary>The total number of items being paginated.</summary>
    [Parameter] public int? ItemCount { get; set; }

    /// <summary>The first index of the items being paginated.</summary>
    [Parameter] public int FirstIndex { get; set; }

    /// <summary>The last index of the items being paginated.</summary>
    [Parameter] public int LastIndex { get; set; }

    /// <summary>Flag to show last full page of results if perPage selected > remaining rows.</summary>
    [Parameter] public bool DefaultToFullPage { get; set; }

    /// <summary>The number of items to be displayed per page.</summary>
    [Parameter] public int PerPage { get; set; }

    /// <summary>The number of the last page.</summary>
    [Parameter] public int LastPage { get; set; }

    /// <summary>This will be shown in pagination toggle span. You can use firstIndex, lastIndex, itemCount, itemsTitle props.</summary>
    [Parameter] public RenderFragment<ToggleTemplateProps> ToggleTemplate { get; set; }

    /// <summary>Function called when user selects number of items per page.</summary>
    [Parameter] public EventCallback<PerPageSelectEventArgs> OnPerPageSelect { get; set; }

    /// <summary>Label for the English word "of".</summary>
    [Parameter] public string OfWord { get; set; } = "of";

    /// <summary>
    /// Component to be used for wrapping the toggle contents.
    /// Use 'button' when you want all of the toggle text to be clickable.
    /// </summary>
    [Parameter] public PerPageComponents PerPageComponent { get; set; }

    private bool IsOpen { get; set; }
    private bool ShowToggle { get => PerPageOptions is not null && PerPageOptions.Length > 0; }

    private string ToggleIndicatorClass
    {
        get => PerPageComponent is PerPageComponents.div ? "pf-c-options-menu__toggle-button-icon" : "pf-c-options-menu__toggle-icon";
    }

    private void OnToggle(bool isOpen)
    {
        IsOpen = isOpen;
    }

    private void OnEnter()
    {
        IsOpen = !IsOpen;
    }

    private void OnSelect()
    {
        IsOpen = !IsOpen;
    }

    private async Task HandleNewPerPage(DropdownItem item)
    {
        OnSelect();

        var newPerPage = int.Parse((string)item.AdditionalAttributes["value"]);
        var newPage    = Page;
        var itemCount  = ItemCount.GetValueOrDefault();

        while (Math.Ceiling(itemCount / (double)newPerPage) < newPage)
        {
            newPage--;
        }

        if (DefaultToFullPage)
        {
            if (itemCount / newPerPage != newPage)
            {
                while (newPage > 1 && itemCount - newPerPage * newPage < 0)
                {
                newPage--;
                }
            }
        }
        var startIdx = (newPage - 1) * newPerPage;
        var endIdx   = newPage * newPerPage;

        await OnPerPageSelect.InvokeAsync(new PerPageSelectEventArgs(newPerPage, newPage, startIdx, endIdx));
    }
}