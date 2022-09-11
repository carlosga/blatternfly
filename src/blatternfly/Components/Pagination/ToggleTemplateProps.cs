namespace Blatternfly.Components;

/// <summary>Toggle template properties.</summary>
public sealed class ToggleTemplateProps
{
    /// <summary>The first index of the items being paginated.</summary>
    public int FirstIndex { get; set; }

    /// <summary>The last index of the items being paginated.</summary>
    public int LastIndex { get; set; }

    /// <summary>The total number of items being paginated.</summary>
    public int? ItemCount { get; set; }

    /// <summary>The type or title of the items being paginated.</summary>
    public string ItemsTitle { get; set; } = "items";

    /// <summary>The word that joins the index and itemCount/itemsTitle.</summary>
    public string OfWord { get; set; } = "of";

    /// Initializes a new instance of the <see cref="ToggleTemplateProps" /> class.
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
