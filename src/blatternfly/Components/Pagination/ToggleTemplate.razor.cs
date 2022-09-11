namespace Blatternfly.Components;

public partial class ToggleTemplate : ComponentBase
{
    /// <summary>The first index of the items being paginated.</summary>
    [Parameter] public int FirstIndex { get; set; }

    /// <summary>The last index of the items being paginated.</summary>
    [Parameter] public int LastIndex { get; set; }

    /// <summary>The total number of items being paginated.</summary>
    [Parameter] public int? ItemCount { get; set; }

    /// <summary>The type or title of the items being paginated.</summary>
    [Parameter] public string ItemsTitle { get; set; } = "items";

    /// <summary>The word that joins the index and itemCount/itemsTitle.</summary>
    [Parameter] public string OfWord { get; set; } = "of";
}