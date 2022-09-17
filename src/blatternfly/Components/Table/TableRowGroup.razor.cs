namespace Blatternfly.Components;

public partial class TableRowGroup : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Modifies the body to allow for expandable rows.</summary>
    [Parameter] public bool IsExpanded { get; set; }

    /// <summary>Flag indicating the <tbody> contains oddly striped rows.</summary>
    [Parameter] public bool IsOddStriped { get; set; }

    /// <summary>Flag indicating the <tbody> contains evenly striped rows.</summary>
    [Parameter] public bool IsEvenStriped { get; set; }

    private string CssClass => new CssBuilder()
        .AddClass("pf-m-expanded"    , IsExpanded)
        .AddClass("pf-m-striped"     , IsOddStriped)
        .AddClass("pf-m-striped-even", IsEvenStriped)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}