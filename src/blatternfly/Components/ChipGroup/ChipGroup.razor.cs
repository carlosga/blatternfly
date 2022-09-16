namespace Blatternfly.Components;

public partial class ChipGroup<TItem> : ComponentBase
{
    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }

    [Inject] private IDomUtils DomUtils { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Flag for having the chip group default to expanded.</summary>
    [Parameter] public bool DefaultIsOpen { get; set; }

    /// <summary>Customizable "Show Less" text string.</summary>
    [Parameter] public string ExpandedText { get; set; } = "Show Less";

    /// <summary>Customizable template string. Use placeholder "${0}" for the overflow chip count.</summary>
    [Parameter] public string CollapsedText { get; set; } = "{0} more";

    /// <summary>Category name text for the chip group category.  If this prop is supplied the chip group with have a label and category styling applied.</summary>
    [Parameter] public string CategoryName { get; set; }

    /// <summary>Aria label for chip group that does not have a category name.</summary>
    [Parameter] public string AriaLabel { get; set; } = "Chip group category";

    /// <summary>Set number of chips to show before overflow.</summary>
    [Parameter] public int NumChips { get; set; } = 3;

    /// <summary>Flag if chip group can be closed.</summary>
    [Parameter] public bool IsClosable { get; set; }

    /// <summary>Aria label for close button.</summary>
    [Parameter] public string CloseBtnAriaLabel { get; set; } = "Close chip group";

    /// <summary>Function that is called when clicking on the chip group close button.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    /// <summary>Function that is called when clicking on the overflow (expand/collapse) chip button.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnOverflowChipClick { get; set; }

    /// <summary>Item template</summary>
    [Parameter] public RenderFragment<TItem> ItemTemplate { get; set; }

    /// <summary>Chip Group items.</summary>
    [Parameter] public IReadOnlyList<TItem> Items { get; set; }

    /// <summary>Position of the tooltip which is displayed if text is truncated.</summary>
    [Parameter] public TooltipPosition TooltipPosition { get; set; } = TooltipPosition.Top;

    private string CssClass => new CssBuilder("pf-c-chip-group")
        .AddClass("pf-m-category", !string.IsNullOrEmpty(CategoryName))
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string ChipGroupId               { get; set; }
    private bool   IsOpen                    { get; set; }
    private string InternalId                { get => AdditionalAttributes.GetPropertyValue(HtmlElement.Id); }
    private string CloseButtonId             { get => $"remove_group_{ChipGroupId}"; }
    private string CloseButtonAriaLabelledBy { get => $"remove_group_{ChipGroupId} {ChipGroupId}"; }
    private string AriaLabelledByValue       { get => !string.IsNullOrEmpty(CategoryName) ? ChipGroupId : null; }
    private string AriaLabelValue            { get => string.IsNullOrEmpty(CategoryName) ? AriaLabel : null; }
    private string CollapsedTextResult       { get => string.Format(CollapsedText, Items.Count - NumChips); }

    private string TooltipId        { get => $"{ChipGroupId}-tooltip"; }
    private bool   IsTooltipVisible { get; set; }

    private ElementReference HeadingRef { get; set; }

    private IEnumerable<TItem> Slice { get => !IsOpen ? Items.Take(NumChips) : Items; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        ChipGroupId = !string.IsNullOrEmpty(InternalId) ? InternalId : ComponentIdGenerator.Generate("pf-c-chip-group");
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

    private async Task ToggleCollapse()
    {
        IsOpen           = !IsOpen;
        IsTooltipVisible = await DomUtils.HasTruncatedWidthAsync(HeadingRef);
    }

    private async Task OnOverflowChipClicked(MouseEventArgs args)
    {
        await ToggleCollapse();
        await OnOverflowChipClick.InvokeAsync(args);
    }
}