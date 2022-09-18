namespace Blatternfly.Layouts;

public partial class Split : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.<summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Adds space between children.</summary>
    [Parameter] public bool HasGutter { get; set; }

    /// <summary>Allows children to wrap.</summary>
    [Parameter] public bool IsWrappable { get; set; }

    /// <summary>Sets the base component to render. defaults to div.</summary>
    [Parameter] public string Component { get; set; } = "div";

    private string CssClass => new CssBuilder("pf-l-split")
        .AddClass("pf-m-gutter", HasGutter)
        .AddClass("pf-m-wrap"  , IsWrappable)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}