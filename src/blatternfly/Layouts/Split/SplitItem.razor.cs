namespace Blatternfly.Layouts;

public partial class SplitItem : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Flag indicating if this Split Layout item should fill the available horizontal space.
    /// </summary>
    [Parameter] public bool IsFilled { get; set; }

    private string CssClass => new CssBuilder("pf-l-split__item")
        .AddClass("pf-m-fill", IsFilled)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}
