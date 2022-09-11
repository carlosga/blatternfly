namespace Blatternfly.Components;

// TODO: Tooltip
public partial class DataListText : ComponentBase
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
    /// Determines which element to render as a data list text. Usually div or span.
    /// </summary>
    [Parameter] public string Component { get; set; } = "span";

    /// <summary>
    /// Determines which wrapping modifier to apply to the data list text.
    /// </summary>
    [Parameter] public DataListWrapModifier? WrapModifier { get; set; }

    /// <summary>
    /// Text to display on the tooltip.
    /// </summary>
    [Parameter] public string Tooltip { get; set; }

    /// <summary>
    /// Callback used to create the tooltip if text is truncated.
    /// </summary>
    [Parameter] public EventCallback<MouseEventArgs> OnMouseEnter { get; set; }

    private string CssClass => new CssBuilder("pf-c-data-list__text")
        .AddClass("pf-m-nowrap"     , WrapModifier is DataListWrapModifier.Nowrap)
        .AddClass("pf-m-truncate"   , WrapModifier is DataListWrapModifier.Truncate)
        .AddClass("pf-m-break-word" , WrapModifier is DataListWrapModifier.BreakWord)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}
