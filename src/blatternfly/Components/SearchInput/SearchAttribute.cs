namespace Blatternfly.Components;

/// <summary>Search attribute</summary>
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
