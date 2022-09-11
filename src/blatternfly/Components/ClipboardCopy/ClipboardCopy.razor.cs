namespace Blatternfly.Components;

public partial class ClipboardCopy : ComponentBase
{
    private const string TextIdPrefix    = "text-input";
    private const string ToggleIdPrefix  = "toggle";
    private const string ContentIdPrefix = "content";

    [Inject]
    private IComponentIdGenerator ComponentIdGenerator { get; set; }

    [Inject]
    private IClipboardService Clipboard { get; set; }

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
    /// Tooltip message to display when hover the copy button.
    /// </summary>
    [Parameter]
    public string HoverTip { get; set; } = "Copy to clipboard";

    /// <summary>
    /// Tooltip message to display when clicking the copy button.
    /// </summary>
    [Parameter]
    public string ClickTip { get; set; } = "Successfully copied to clipboard!";

    /// <summary>
    /// Aria-label to use on the TextInput.
    /// </summary>
    [Parameter]
    public string TextAriaLabel { get; set; } = "Copyable input";

    /// <summary>
    /// Aria-label to use on the ClipboardCopyToggle.
    /// </summary>
    [Parameter]
    public string ToggleAriaLabel { get; set; } = "Show content";

    /// <summary>
    /// Flag to show if the input is read only.
    /// </summary>
    [Parameter]
    public bool IsReadOnly { get; set; }

    /// <summary>
    /// Flag to determine if clipboard copy is in the expanded state initially.
    /// </summary>
    [Parameter]
    public bool IsExpanded { get; set; }

    /// <summary>
    /// Flag to determine if clipboard copy content includes code.
    /// </summary>
    [Parameter]
    public bool IsCode { get; set; }

    /// <summary>
    /// Flag to determine if inline clipboard copy should be block styling.
    /// </summary>
    [Parameter]
    public bool IsBlock { get; set; }

    /// <summary>
    /// Adds Clipboard Copy variant styles.
    /// </summary>
    [Parameter]
    public ClipboardCopyVariant Variant { get; set; } = ClipboardCopyVariant.Inline;

    /// <summary>
    /// Position of the copy button tooltip.
    /// </summary>
    [Parameter]
    public TooltipPosition Position { get; set; } = TooltipPosition.Top;

    /// <summary>
    /// Max width of the copy button tooltip.
    /// </summary>
    [Parameter]
    public string MaxWidth { get; set; } = "150px";

    /// <summary>
    /// Exit delay on the copy button tooltip.
    /// </summary>
    [Parameter]
    public int ExitDelay { get; set; } = 1600;

    /// <summary>
    /// Entry delay on the copy button tooltip.
    /// </summary>
    [Parameter]
    public int EntryDelay { get; set; } = 300;

    /// <summary>
    /// Delay in ms before the tooltip message switch to hover tip.
    /// </summary>
    [Parameter]
    public int SwitchDelay { get; set; } = 2000;

    /// <summary>
    /// A function that is triggered on clicking the copy button.
    /// </summary>
    [Parameter]
    public EventCallback OnCopy { get; set; }

    /// <summary>
    /// A function that is triggered on changing the text.
    /// </summary>
    [Parameter]
    public EventCallback<ChangeEventArgs> OnChange { get; set; }

    /// <summary>
    /// The text which is copied.
    /// </summary>
    [Parameter]
    public string Text { get; set; }

    /// <summary>
    /// Additional actions for inline clipboard copy. Should be wrapped with ClipboardCopyAction.
    /// </summary>
    [Parameter]
    public RenderFragment AdditionalActions { get; set; }

    private string CssClass => new CssBuilder("pf-c-clipboard-copy")
        .AddClass("pf-m-inline"  , Variant is ClipboardCopyVariant.InlineCompact)
        .AddClass("pf-m-block"   , IsBlock)
        .AddClass("pf-m-expanded", IsExpanded)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string ClipboardCopyTextCssClass => new CssBuilder("pf-c-clipboard-copy__text")
        .AddClass("pf-m-code", IsCode)
        .Build();

    private string _id;
    private string CopyButtonId { get => $"copy-button-{_id}"; }

    private string TextInputId { get => $"{TextIdPrefix}-{_id}"; }

    private string ToggleId { get => $"{ToggleIdPrefix}-{_id}"; }

    private string ToggleTextId { get => $"{TextIdPrefix}-{_id}"; }

    private string ToggleContentId { get => $"{ContentIdPrefix}-{_id}"; }

    private string ExpandedId { get => $"content-${_id}"; }

    private string TextId { get => $"{TextIdPrefix}-{_id}"; }

    private bool Copied { get; set; }

    private bool IsTextInputReadOnly { get => IsReadOnly || IsExpanded; }

    private string ClipboardButtonText { get => Copied ? ClickTip : @HoverTip; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _id = ComponentIdGenerator.Generate("pf-c-clipboard-copy");
    }

    private void OnExpandContent(MouseEventArgs _)
    {
        IsExpanded = !IsExpanded;
    }

    private async Task OnClipboardCopyClick(MouseEventArgs _)
    {
        Copied = true;
        await Clipboard.WriteTextAsync(Text);
    }
}
