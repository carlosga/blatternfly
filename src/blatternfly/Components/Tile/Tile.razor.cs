namespace Blatternfly.Components;

public partial class Tile : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Title of the tile.</summary>
    [Parameter] public string Title { get; set; }

    /// <summary>Icon in the tile title.</summary>
    [Parameter] public RenderFragment Icon { get; set; }

    /// <summary>Flag indicating if the tile is selected.</summary>
    [Parameter] public bool IsSelected { get; set; }

    /// <summary>Flag indicating if the tile is disabled.</summary>
    [Parameter] public bool IsDisabled { get; set; }

    /// <summary>Flag indicating if the tile header is stacked.</summary>
    [Parameter] public bool IsStacked { get; set; }

    /// <summary>Flag indicating if the stacked tile icon is large.</summary>
    [Parameter] public bool IsDisplayLarge { get; set; }

    private string CssClass => new CssBuilder("pf-c-tile")
      .AddClass("pf-m-selected"  , IsSelected)
      .AddClass("pf-m-disabled"  , IsDisabled)
      .AddClass("pf-m-display-lg", IsDisplayLarge)
      .AddClassFromAttributes(AdditionalAttributes)
      .Build();

    private string HeaderCssClass => new CssBuilder("pf-c-tile__header")
      .AddClass("pf-m-stacked", IsStacked)
      .Build();

    private string AriaSelected { get => IsSelected ? "true" : null; }
}