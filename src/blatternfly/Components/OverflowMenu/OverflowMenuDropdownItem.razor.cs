namespace Blatternfly.Components;

public partial class OverflowMenuDropdownItem : ComponentBase
{
    [CascadingParameter(Name = "IsBelowBreakpoint")]
    public bool IsBelowBreakpoint { get; set; }

    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Indicates when a dropdown item shows and hides the corresponding list item.
    /// </summary>
    [Parameter]
    public bool IsShared { get; set; }

    /// <summary>
    /// Indicates the index of the list item.
    /// </summary>
    [Parameter]
    public int Index { get; set; }
}