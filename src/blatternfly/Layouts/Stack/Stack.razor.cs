namespace Blatternfly.Layouts;

public partial class Stack : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Sets the base component to render. defaults to div.</summary>
    [Parameter] public string Component { get; set; } = "div";

    /// <summary>Adds space between children.</summary>
    [Parameter] public bool HasGutter { get; set; }

    private string CssClass => new CssBuilder("pf-l-stack")
        .AddClass("pf-m-gutter", HasGutter)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}
