namespace Blatternfly.Components;

public partial class DataListContent : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Identify the DataListContent item.</summary>
    [Parameter] public string Id { get; set; }

    /// <summary>Id for the row.</summary>
    [Parameter] public string Rowid { get; set; }

    /// <summary>Flag to show if the expanded content of the DataList item is visible.</summary>
    [Parameter] public bool IsHidden { get; set; }

    /// <summary>Flag to remove padding from the expandable content.</summary>
    [Parameter] public bool HasNoPadding { get; set; }

    /// <summary>Adds accessible text to the DataList toggle.</summary>
    [Parameter] public string AriaLabel { get; set; }

    private string CssClass => new CssBuilder("pf-c-data-list__expandable-content")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string BodyCssClass => new CssBuilder("pf-c-data-list__expandable-content-body")
        .AddClass("pf-m-no-padding", HasNoPadding)
        .Build();
}
