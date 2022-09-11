namespace Blatternfly.Components;

public partial class OverflowMenuGroup : ComponentBase
{
    [CascadingParameter(Name = "IsBelowBreakpoint")] public bool IsBelowBreakpoint { get; set; }

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
    /// Modifies the overflow menu group visibility.
    /// </summary>
    [Parameter]
    public bool IsPersistent { get; set; }

    /// <summary>
    /// Indicates a button or icon group.
    /// </summary>
    [Parameter]
    public OverflowMenuGroupType? GroupType { get; set;  }

    private string CssClass => new CssBuilder("pf-c-overflow-menu__group")
        .AddClass("pf-m-button-group"     , GroupType is OverflowMenuGroupType.Button)
        .AddClass("pf-m-icon-button-group", GroupType is OverflowMenuGroupType.Icon)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}