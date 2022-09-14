namespace Blatternfly.Components;

public partial class TextContent : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Flag to indicate the all links in a the content block have visited styles applied if the browser determines the link has been visited.</summary>
    [Parameter] public bool IsVisited { get; set; }

    private string CssClass => new CssBuilder("pf-c-content")
        .AddClass("pf-m-visited", IsVisited)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}
