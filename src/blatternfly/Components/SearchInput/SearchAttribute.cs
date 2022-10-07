namespace Blatternfly.Components;

/// <summary>
/// Properties for adding search attributes to an advanced search input. These properties must
/// be passed in as an object within an array to the search input component's attribute properrty.
/// </summary>
public sealed class SearchAttribute
{
    /// <summary>
    /// The search attribute's value to be provided in the search input's query string.
    /// It should have no spaces and be unique for every attribute.
    /// </summary>
    public string Attribute { get; set; }

    /// <summary>The search attribute's display name. It is used to label the field in the advanced search menu.</summary>
    public string Display { get; set; }
}
