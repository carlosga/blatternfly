namespace Blatternfly.Components;

public class Label : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    public ElementReference Element { get; protected set; }

    /// Color of the label.
    [Parameter] public LabelColor? Color { get; set; } = LabelColor.Grey;

    /// Variant of the label.
    [Parameter] public LabelVariant Variant { get; set; } = LabelVariant.Filled;

    /// Flag indicating the label is compact.
    [Parameter] public bool IsCompact { get; set; }

    /// Flag indicating the label text should be truncated.
    [Parameter] public bool IsTruncated { get; set; }

    /// Position of the tooltip which is displayed if text is truncated.
    [Parameter] public TooltipPosition TooltipPosition { get; set; } = TooltipPosition.Top;

    /// Icon added to the left of the label text.
    [Parameter] public RenderFragment Icon { get; set; }

    /// Href for a label that is a link. If present, the label will change to an anchor element.
    [Parameter] public string Href { get; set; }

    /// Close click callback for removable labels. If present, label will have a close button.
    [Parameter] public EventCallback<MouseEventArgs> OnClose { get; set; }

    /// Node for custom close button.
    [Parameter] public RenderFragment CloseBtn { get; set; }

    /// Aria label for close button.
    [Parameter] public string CloseBtnAriaLabel { get; set; }

    /// Flag indicating if the label is an overflow label.
    [Parameter] public bool IsOverflowLabel { get; set; }

    /// Label click.
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }

    private string CssClass => new CssBuilder("pf-c-label")
        .AddClass("pf-m-blue"    , Color is LabelColor.Blue)
        .AddClass("pf-m-cyan"    , Color is LabelColor.Cyan)
        .AddClass("pf-m-green"   , Color is LabelColor.Green)
        .AddClass("pf-m-orange"  , Color is LabelColor.Orange)
        .AddClass("pf-m-purple"  , Color is LabelColor.Purple)
        .AddClass("pf-m-red"     , Color is LabelColor.Red)
        .AddClass("pf-m-gold"    , Color is LabelColor.Gold)
        .AddClass("pf-m-outline" , Variant is LabelVariant.Outline)
        .AddClass("pf-m-overflow", IsOverflowLabel)
        .AddClass("pf-m-compact" , IsCompact)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string InternalId            { get => AdditionalAttributes.GetPropertyValue(HtmlAttributes.Id); }
    private string LabelComponentChildId { get; set; }
    private string TooltipId             { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        LabelComponentChildId = InternalId ?? ComponentIdGenerator.Generate("pf-c-label");
        TooltipId             = $"{LabelComponentChildId}-tooltip";
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var labelComponent    = IsOverflowLabel ? "button" : "span";
        var closeBtnAriaLabel = !string.IsNullOrEmpty(CloseBtnAriaLabel) ? CloseBtnAriaLabel : $"Close Label";

        builder.OpenElement(0, labelComponent);
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddAttribute(3, "onclick", EventCallback.Factory.Create(this, OnClick));

        if (IsTruncated)
        {
            builder.OpenComponent<Tooltip>(4);
            builder.AddAttribute(5, "id", TooltipId);
            builder.AddAttribute(6, "Reference", LabelComponentChildId);
            builder.AddAttribute(7, "Position", TooltipPosition);
            builder.AddAttribute(8, "Content", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
            {
                innerBuilder.AddContent(9, ChildContent);
            });
            builder.AddAttribute(10, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
            {
                RenderLabelComponentChild(innerBuilder, true);
            });

            builder.CloseComponent();
        }
        else
        {
            RenderLabelComponentChild(builder);
        }

        if (OnClose.HasDelegate)
        {
            if (CloseBtn is not null)
            {
                builder.AddContent(24, CloseBtn);
            }
            else
            {
                builder.OpenComponent<Button>(25);
                builder.AddAttribute(26, "Type", ButtonType.Button);
                builder.AddAttribute(27, "Variant", ButtonVariant.Plain);
                builder.AddAttribute(28, "AriaLabel", closeBtnAriaLabel);
                builder.AddAttribute(29, "OnClick", EventCallback.Factory.Create(this, OnClose));
                builder.AddAttribute(30, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
                {
                    innerBuilder.OpenComponent<TimesIcon>(31);
                    innerBuilder.CloseComponent();
                });
                builder.CloseComponent();
            }
        }

        builder.CloseElement();
    }

    protected void RenderLabelComponentChild(RenderTreeBuilder builder, bool withReferenceId = false)
    {
        var component = !string.IsNullOrEmpty(Href) ? "a" : "span";

        builder.OpenElement(11, component);
        builder.AddAttribute(12, "id", withReferenceId ? LabelComponentChildId : null);
        builder.AddAttribute(13, "class", "pf-c-label__content");
        if (!string.IsNullOrEmpty(Href))
        {
            builder.AddAttribute(14, "href", Href);
        }
        if (Icon is not null)
        {
            builder.OpenElement(15, "span");
            builder.AddAttribute(16, "class", "pf-c-label__icon");
            builder.AddContent(17, Icon);
            builder.CloseElement();
        }
        if (IsTruncated)
        {
            builder.OpenElement(18, "span");
            builder.AddAttribute(19, "class", "pf-c-label__text");
            builder.AddContent(20, ChildContent);
            builder.CloseElement();
        }
        else
        {
            builder.AddContent(21, ChildContent);
        }
        builder.AddElementReferenceCapture(22, __reference => Element = __reference);
        builder.CloseElement();
    }
}
