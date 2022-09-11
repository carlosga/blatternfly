namespace Blatternfly.Components;

/// <summary>Pagination titles.</summary>
public sealed class PaginationTitles
{
    /// <summary>The title of a page displayed beside the page number.</summary>
    public string Page { get; set; }

    /// <summary>The title of a page displayed beside the page number (plural form).</summary>
    public string Pages { get; set; }

    /// <summary>The type or title of the items being paginated.</summary>
    public string Items { get; set; }

    /// <summary>The title of the pagination options menu.</summary>
    public string ItemsPerPage { get; set; } = "Items per page";

    /// <summary>The suffix to be displayed after each option on the options menu dropdown.</summary>
    public string PerPageSuffix { get; set; } = "per page";

    /// <summary>Accessible label for the button which moves to the first page.</summary>
    public string ToFirstPage { get; set; } = "Go to first page";

    /// <summary>Accessible label for the button which moves to the previous page.</summary>
    public string ToPreviousPage { get; set; } = "Go to previous page";

    /// <summary>Accessible label for the button which moves to the last page.</summary>
    public string ToLastPage { get; set; } = "Go to last page";

    /// <summary>Accessible label for the button which moves to the next page.</summary>
    public string ToNextPage { get; set; } = "Go to next page";

    /// <summary>Accessible label for the options toggle.</summary>
    public string OptionsToggle { get; set; }

    /// <summary>Accessible label for the input displaying the current page.</summary>
    public string CurrPage { get; set; } = "Current page";

    /// <summary>Accessible label for the pagination component.</summary>
    public string PaginationTitle { get; set; } = "Pagination";

    /// <summary>Accessible label for the English word "of".</summary>
    public string OfWord { get; set; } = "of";
}
