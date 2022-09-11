namespace Blatternfly.Components;

public partial class LabelGroup<TItem> : ComponentBase
{
    [Inject]
    private IComponentIdGenerator ComponentIdGenerator { get; set; }

    [Inject]
    private IDomUtils DomUtils { get; set; }

    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Flag for having the label group default to expanded.
    /// </summary>
    [Parameter] public bool DefaultIsOpen { get; set; }

    /// <summary>
    /// Customizable "Show Less" text string.
    /// </summary>
    [Parameter] public string ExpandedText { get; set; } = "Show Less";

    /// <summary>
    /// Customizable template string. Use placeholder "{0}" for the overflow label count.
    /// </summary>
    [Parameter] public string CollapsedText { get; set; } = "{0} more";

    /// <summary>
    /// Category name text for the label group category.  If this prop is supplied the label group with have a label and category styling applied.
    /// </summary>
    [Parameter] public string CategoryName { get; set; }

    /// <summary>
    /// Aria label for label group that does not have a category name.
    /// </summary>
    [Parameter] public string AriaLabel { get; set; } = "Label group category";

    /// <summary>
    /// Set number of labels to show before overflow.
    /// </summary>
    [Parameter] public int NumLabels { get; set; } = 3;

    /// <summary>
    /// Flag if label group can be closed.
    /// </summary>
    [Parameter] public bool IsClosable { get; set; }

    /// <summary>
    /// Flag indicating the labels in the group are compact.
    /// </summary>
    [Parameter] public bool IsCompact { get; set; }

    /// <summary>
    /// Aria label for close button.
    /// </summary>
    [Parameter] public string CloseBtnAriaLabel { get; set; } = "Close label group";

    /// <summary>
    /// Function that is called when clicking on the label group close button.
    /// </summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    /// <summary>
    /// Flag to implement a vertical layout.
    /// </summary>
    [Parameter] public bool IsVertical { get; set; }

    /// <summary>
    /// @beta Control for adding new labels.
    /// </summary>
    [Parameter] public RenderFragment AddLabelControl { get; set; }

    /// <summary>
    /// Item template
    /// </summary>
    [Parameter] public RenderFragment<TItem> ItemTemplate { get; set; }

    /// <summary>
    /// Label Group items.
    /// </summary>
    [Parameter] public IReadOnlyList<TItem> Items { get; set; }

    /// <summary>
    /// Position of the tooltip which is displayed if text is truncated.
    /// </summary>
    [Parameter] public TooltipPosition TooltipPosition { get; set; } = TooltipPosition.Top;

    private string CssClass => new CssBuilder("pf-c-label-group")
        .AddClass("pf-m-category", !string.IsNullOrEmpty(CategoryName))
        .AddClass("pf-m-vertical", IsVertical)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private IEnumerable<TItem> Slice { get => !IsOpen ? Items.Take(NumLabels) : Items; }

    private bool   IsOpen                    { get; set; }
    private string LabelGroupId              { get; set; }
    private string InternalId                { get => AdditionalAttributes.GetPropertyValue(HtmlAttributes.Id); }
    private string AriaLabelValue            { get => string.IsNullOrEmpty(CategoryName) ? AriaLabel : null; }
    private string AriaLabelledByValue       { get => !string.IsNullOrEmpty(CategoryName) ? LabelGroupId : null; }
    private string CollapsedTextResult       { get => string.Format(CollapsedText, Items.Count - NumLabels); }
    private string CloseButtonId             { get => $"remove_group_{LabelGroupId}"; }
    private string CloseButtonAriaLabelledBy { get => $"remove_group_{LabelGroupId} {LabelGroupId}"; }
    private string TooltipId                 { get => $"{LabelGroupId}-tooltip"; }
    private bool   IsTooltipVisible          { get; set; }

    private ElementReference HeadingRef { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        LabelGroupId = !string.IsNullOrEmpty(InternalId) ? InternalId : ComponentIdGenerator.Generate("pf-c-chip__group");
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            IsTooltipVisible = await DomUtils.HasTruncatedWidthAsync(HeadingRef);
            if (IsTooltipVisible)
            {
                StateHasChanged();
            }
        }
}

    private async Task ToggleCollapse(MouseEventArgs _)
    {
        IsOpen           = !IsOpen;
        IsTooltipVisible = await DomUtils.HasTruncatedWidthAsync(HeadingRef);
    }
}