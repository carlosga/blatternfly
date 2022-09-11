namespace Blatternfly.Components;

public partial class ClipboardCopyExpanded : ComponentBase
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
    /// On change callback.
    /// </summary>
    [Parameter] public EventCallback<ChangeEventArgs> OnChange { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the element is readonly.
    /// </summary>
    [Parameter] public bool IsReadOnly { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the element is showing code.
    /// </summary>
    [Parameter] public bool IsCode { get; set; }

    private string CssClass => new CssBuilder("pf-c-clipboard-copy__expandable-content")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string IsContentEditable { get => !IsReadOnly ? "true" : "false"; }
}
