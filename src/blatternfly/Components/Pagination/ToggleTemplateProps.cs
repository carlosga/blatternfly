namespace Blatternfly.Components;

public sealed class ToggleTemplateProps
{
    /// The first index of the items being paginated.
    public int FirstIndex { get; set; }

    /// The last index of the items being paginated.
    public int LastIndex { get; set; }

    /// The total number of items being paginated.
    public int? ItemCount { get; set; }

    /// The type or title of the items being paginated.
    public string ItemsTitle { get; set; } = "items";

    /// The word that joins the index and itemCount/itemsTitle.
    public string OfWord { get; set; } = "of";

    public ToggleTemplateProps(
        int    firstIndex,
        int    lastIndex,
        int?   itemCount,
        string itemsTitle,
        string ofWord)
    {
        FirstIndex = firstIndex;
        LastIndex  = lastIndex;
        ItemCount  = itemCount;
        ItemsTitle = itemsTitle;
        OfWord     = ofWord;
    }
}
