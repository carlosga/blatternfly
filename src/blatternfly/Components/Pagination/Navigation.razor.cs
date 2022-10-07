namespace Blatternfly.Components;

public partial class Navigation : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Accessible label for the input displaying the current page.</summary>
    [Parameter] public string CurrPage { get; set; } = "Current page";

    /// <summary>The number of first page where pagination starts.</summary>
    [Parameter] public int FirstPage { get; set; }

    /// <summary>Flag indicating if the pagination is compact.</summary>
    [Parameter] public bool IsCompact { get; set; }

    /// <summary>Flag indicating if the pagination is disabled.</summary>
    [Parameter] public bool IsDisabled { get; set; }

    /// <summary>Total number of items.</summary>
    [Parameter] public int? ItemCount { get; set; }

    /// <summary>The number of the last page.</summary>
    [Parameter] public int LastPage { get; set; }

    /// <summary>Accessible label for the English word "of".</summary>
    [Parameter] public string OfWord { get; set; } = "of";

    /// <summary>Function called when user clicks to navigate to first page.</summary>
    [Parameter] public EventCallback<int> OnFirstClick { get; set; }

    /// <summary>Function called when user clicks to navigate to last page.</summary>
    [Parameter] public EventCallback<int> OnLastClick { get; set; }

    /// <summary>Function called when user clicks to navigate to next page.</summary>
    [Parameter] public EventCallback<int> OnNextClick { get; set; }

    /// <summary>Function called when user inputs page number.</summary>
    [Parameter] public EventCallback<int> OnPageInput { get; set; }

    /// <summary>Function called when user clicks to navigate to previous page.</summary>
    [Parameter] public EventCallback<int> OnPreviousClick { get; set; }

    /// <summary>Function called when page is changed.</summary>
    [Parameter] public EventCallback<SetPageEventArgs> OnSetPage { get; set; }

    /// <summary>The number of the current page.</summary>
    [Parameter] public int Page { get; set; }

    /// <summary>The title of a page displayed beside the page number.</summary>
    [Parameter] public string PagesTitle { get; set; }

    /// <summary>The title of a page displayed beside the page number (the plural form).</summary>
    [Parameter] public string PagesTitlePlural { get; set; }

    /// <summary>Accessible label for the pagination component.</summary>
    [Parameter] public string PaginationTitle { get; set; } = "Pagination";

    /// <summary>Number of items per page.</summary>
    [Parameter] public int PerPage { get; set; }

    /// <summary>Accessible label for the button which moves to the first page.</summary>
    [Parameter] public string ToFirstPage { get; set; } = "Go to first page";

    /// <summary>Accessible label for the button which moves to the last page.</summary>
    [Parameter] public string ToLastPage { get; set; } = "Go to last page";

    /// <summary>Accessible label for the button which moves to the next page.</summary>
    [Parameter] public string ToNextPage { get; set; } = "Go to next page";

    /// <summary>Accessible label for the button which moves to the previous page.</summary>
    [Parameter] public string ToPreviousPage { get; set; } = "Go to previous page";

    private string CssClass => new CssBuilder("pf-c-pagination__nav")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private int UserInputPage { get; set; }

    private string PagesTitleText
    {
        get => !string.IsNullOrEmpty(PagesTitle)
            ? Utils.Pluralize(LastPage, PagesTitle, PagesTitlePlural)
                : LastPage.ToString();
    }

    protected override void OnInitialized()
    {
        UserInputPage = Page;
    }

    private async Task FirstHandler(MouseEventArgs _)
    {
        await OnFirstClick.InvokeAsync(1);
        await HandleNewPage(1);
        UserInputPage = 1;
    }

    private async Task PreviousHandler(MouseEventArgs _)
    {
        var newPage = Page - 1 >= 1 ? Page - 1 : 1;
        await OnPreviousClick.InvokeAsync(newPage);
        await HandleNewPage(newPage);
        UserInputPage = newPage;
    }

    private async Task NextHandler(MouseEventArgs _)
    {
        var newPage = Page + 1 <= LastPage ? Page + 1 : LastPage;
        await OnNextClick.InvokeAsync(newPage);
        await HandleNewPage(newPage);
        UserInputPage = newPage;
    }

    private async Task LastHandler(MouseEventArgs _)
    {
        await OnLastClick.InvokeAsync(LastPage);
        await HandleNewPage(LastPage);
        UserInputPage = LastPage;
    }

    private static int ParseInteger(string value, int lastPage)
    {
        if (!int.TryParse(value, out var inputPage))
        {
            inputPage = inputPage > lastPage ? lastPage : inputPage;
            inputPage = inputPage < 1 ? 1 : inputPage;
        }
        return inputPage;
    }

    private void OnChange(ChangeEventArgs args)
    {
        var inputPage = ParseInteger(args.Value as string, LastPage);
        UserInputPage = inputPage;
    }

    private async Task OnKeyDown(KeyboardEventArgs args)
    {
        if (args.Key == Keys.Enter)
        {
            await OnPageInput.InvokeAsync(UserInputPage);
            await HandleNewPage(UserInputPage);
        }
    }

    private async Task HandleNewPage(int newPage)
    {
        var startIdx = (newPage - 1) * PerPage;
        var endIdx   = newPage * PerPage;
        await OnSetPage.InvokeAsync(new SetPageEventArgs(newPage, PerPage, startIdx, endIdx));
    }
}