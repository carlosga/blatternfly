namespace Blatternfly.Components;

public record SearchAttribute
{
    /// The search attribute's value to be provided in the search input's query string.
    /// It should have no spaces and be unique for every attribute.
    public string Attribute { get; set; }

    /// The search attribute's display name. It is used to label the field in the advanced search menu.
    public RenderFragment Display { get; set; }
}
