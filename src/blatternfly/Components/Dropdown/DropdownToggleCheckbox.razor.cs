namespace Blatternfly.Components;

public partial class DropdownToggleCheckbox : ComponentBase
{
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
    /// Flag to show if the checkbox selection is valid or invalid.
    /// </summary>
    [Parameter]
    public bool IsValid { get; set; } = true;

    /// <summary>
    /// Flag to show if the checkbox is disabled.
    /// </summary>
    [Parameter]
    public bool IsDisabled { get; set; }

    /// <summary>
    /// Flag to show if the checkbox is checked.
    /// </summary>
    [Parameter]
    public bool IsChecked { get; set; }

    private string CssClass => new CssBuilder("pf-c-dropdown__toggle-check")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string InternalId { get => AdditionalAttributes.GetPropertyValue(HtmlAttributes.Id); }

    private bool IsInvalid { get => !IsValid; }
}