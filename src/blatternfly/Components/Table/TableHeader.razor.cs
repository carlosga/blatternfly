namespace Blatternfly.Components;

public partial class TableHeader : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Won't wrap the table head if true.</summary>
    [Parameter] public bool NoWrap { get; set; }

    /// <summary>Indicates the 'thead' contains a nested header.</summary>
    [Parameter] public bool HasNestedHeader { get; set; }

    private string CssClass => new CssBuilder("")
        .AddClass("pf-m-nowrap", NoWrap)
        .AddClass("pf-m-nested-column-header", HasNestedHeader)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}