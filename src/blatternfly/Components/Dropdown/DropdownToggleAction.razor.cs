namespace Blatternfly.Components;

public partial class DropdownToggleAction : ComponentBase
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
    /// Flag to show if the action button is disabled.
    /// </summary>
    [Parameter] public bool IsDisabled { get; set; }

    /// <summary>
    /// A callback for when the action button is clicked.
    /// </summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    private string CssClass => new CssBuilder("pf-c-dropdown__toggle-button")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string DisabledValue { get => IsDisabled ? "true" : null; }
}