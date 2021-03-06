namespace Blatternfly.Components;

public sealed class PaginationTitles
{
    /// The title of a page displayed beside the page number.
    public string Page { get; set; }

    /// The title of a page displayed beside the page number (plural form).
    public string Pages { get; set; }

    /// The type or title of the items being paginated.
    public string Items { get; set; }

    /// The title of the pagination options menu.
    public string ItemsPerPage { get; set; } = "Items per page";

    /// The suffix to be displayed after each option on the options menu dropdown.
    public string PerPageSuffix { get; set; } = "per page";

    /// Accessible label for the button which moves to the first page.
    public string ToFirstPage { get; set; } = "Go to first page";

    /// Accessible label for the button which moves to the previous page.
    public string ToPreviousPage { get; set; } = "Go to previous page";

    /// Accessible label for the button which moves to the last page.
    public string ToLastPage { get; set; } = "Go to last page";

    /// Accessible label for the button which moves to the next page.
    public string ToNextPage { get; set; } = "Go to next page";

    /// Accessible label for the options toggle.
    public string OptionsToggle { get; set; }

    /// Accessible label for the input displaying the current page.
    public string CurrPage { get; set; } = "Current page";

    /// Accessible label for the pagination component.
    public string PaginationTitle { get; set; } = "Pagination";

    /// Accessible label for the English word "of".
    public string OfWord { get; set; } = "of";
}
