namespace Blatternfly.Layouts;

public partial class GalleryItem : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Sets the base component to render. defaults to div.</summary>
    [Parameter] public string Component { get; set; } = "div";
}
