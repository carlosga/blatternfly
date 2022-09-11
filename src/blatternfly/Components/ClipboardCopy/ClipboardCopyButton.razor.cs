namespace Blatternfly.Components;

public partial class ClipboardCopyButton : ComponentBase
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
    /// Callback for the copy when the button is clicked.
    /// </summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    /// <summary>
    /// ID of the copy button.
    /// </summary>
    [Parameter] public string id { get; set; }

    /// <summary>
    /// ID of the content that is being copied.
    /// </summary>
    [Parameter] public string TextId { get; set; }

    /// <summary>
    /// Exit delay on the copy button tooltip.
    /// </summary>
    [Parameter] public int ExitDelay { get; set; } = 0;

    /// <summary>
    /// Entry delay on the copy button tooltip.
    /// </summary>
    [Parameter] public int EntryDelay { get; set; } = 300;

    /// <summary>
    /// Max width of the copy button tooltip.
    /// </summary>
    [Parameter] public string MaxWidth { get; set; } = "100px";

    /// <summary>
    /// Position of the copy button tooltip.
    /// </summary>
    [Parameter] public TooltipPosition Position { get; set; } = TooltipPosition.Top;

    /// <summary>
    /// Aria-label for the copy button.
    /// </summary>
    [Parameter] public string AriaLabel { get; set; } = "Copyable input";

    /// <summary>
    /// Variant of the copy button.
    /// </summary>
    [Parameter] public ButtonVariant Variant { get; set; } = ButtonVariant.Control;

    private string TooltipId      { get => $"{id}-tooltip"; }
    private string AriaLabelledBy { get => $"{id} {TextId}"; }

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();
        if (Variant is not ButtonVariant.Control && Variant is not ButtonVariant.Plain)
        {
            throw new InvalidOperationException("ClipboardCopyButton: Allowed Variant values are Control and Plain.");
        }
    }
}
