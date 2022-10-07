namespace Blatternfly.Components;

/// <summary>
/// Properties to customize the content and behavior of the pagination dropdown options.
/// These properties should be passed into the pagination component's perPageOptions property.
/// </summary>
public sealed class PerPageOptions
{
    /// <summary>The text title of the option, which is rendered inside the pagination dropdown menu.</summary>
    public string Title { get; set; }

    /// <summary>The value of the option, which determines how many items are displayed per page.</summary>
    public int Value { get; set; }

    internal string Action { get => $"per-page-{Value}"; }
}
