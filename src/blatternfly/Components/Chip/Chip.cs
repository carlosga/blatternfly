using Blatternfly.Interop;
using Microsoft.AspNetCore.Components.CompilerServices;

namespace Blatternfly.Components;

public class Chip : ComponentBase
{
    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }

    [Inject] private IDomUtils DomUtils { get; set; }

    /// <summary>
    /// Html element reference.
    /// </summary>
    public ElementReference Element { get; protected set; }

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
    /// Aria Label for close button.
    /// </summary>
    [Parameter]
    public string CloseBtnAriaLabel { get; set; } = "close";

    /// <summary>
    /// Flag indicating if the chip is an overflow chip.
    /// </summary>
    [Parameter]
    public bool IsOverflowChip { get; set; }

    /// <summary>
    /// Flag indicating if chip is read only.
    /// </summary>
    [Parameter]
    public bool IsReadOnly { get; set; }

    /// <summary>
    /// Function that is called when clicking on the chip close button.
    /// </summary>
    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }

    /// <summary>
    /// Component that will be used for chip. It is recommended that <button /> or <li />  are used when the chip is an overflow chip.
    /// </summary>
    [Parameter]
    public string Component { get; set; } = "div";

    /// <summary>
    /// Position of the tooltip which is displayed if text is truncated.
    /// </summary>
    [Parameter]
    public TooltipPosition TooltipPosition { get; set; } = TooltipPosition.Top;

    /// <summary>
    /// Css property expressed in percentage or any css unit that overrides the default value of the max-width of the chip's text.
    /// </summary>
    [Parameter]
    public string TextMaxWidth { get; set; }

    private string CssClass => new CssBuilder("pf-c-chip")
        .AddClass("pf-m-overflow", IsOverflowChip)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string CssStyle => new StyleBuilder()
        .AddStyle("--pf-c-chip__text--MaxWidth", TextMaxWidth, !string.IsNullOrEmpty(TextMaxWidth))
        .AddStyleFromAttributes(AdditionalAttributes)
        .Build();

    private string InternalId       { get => AdditionalAttributes.GetPropertyValue(HtmlAttributes.Id); }
    private string Id               { get; set; }
    private bool   IsTooltipVisible { get; set; }
    private string TooltipId        { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Id        = InternalId ?? ComponentIdGenerator.Generate("pf-c-chip");
        TooltipId = $"{Id}-tooltip";
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (IsOverflowChip)
        {
            builder.OpenElement(0, Component);
            builder.AddAttribute(1, "style", CssStyle);
            builder.AddAttribute(2, "class", CssClass);
            builder.AddAttribute(3, "onclick", EventCallback.Factory.Create(this, OnClick));

            if (Component == "button")
            {
                builder.AddAttribute(4, "type", "button");
            }

            builder.OpenElement(5, "span");
            builder.AddAttribute(6, "class", "pf-c-chip__text");
            builder.AddContent(7, ChildContent);
            builder.CloseElement();

            builder.CloseElement();
        }
        else if (IsTooltipVisible)
        {
            builder.OpenComponent<Tooltip>(8);
            builder.AddAttribute(9, "id", TooltipId);
            builder.AddAttribute(10, "Reference", RuntimeHelpers.TypeCheck(Id));
            builder.AddAttribute(11, "Position", RuntimeHelpers.TypeCheck((TooltipPosition?)TooltipPosition));
            builder.AddAttribute(12, "Content", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
            {
                innerBuilder.AddContent(13, ChildContent);
            });
            builder.AddAttribute(14, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
            {
                RenderInnerChip(innerBuilder, 15);
            });
            builder.CloseComponent();
        }
        else
        {
            RenderInnerChip(builder, 16);
        }
    }

    private void RenderInnerChip(RenderTreeBuilder builder, int index)
    {
        builder.OpenElement(index++, Component);
        builder.AddAttribute(index++, "style", CssStyle);
        builder.AddAttribute(index++, "class", CssClass);

        if (Component == "button")
        {
            builder.AddAttribute(index++, "type", "button");
        }

        builder.OpenElement(index++, "span");
        builder.AddAttribute(index++, "class", "pf-c-chip__text");
        builder.AddAttribute(index++, "id", Id);
        builder.AddElementReferenceCapture(index++, __reference => Element = __reference);
        builder.AddContent(index++, ChildContent);
        builder.CloseElement();

        if (!IsReadOnly)
        {
            builder.OpenComponent<Button>(index++);
            builder.AddAttribute(index++, "OnClick", EventCallback.Factory.Create(this, OnClick));
            builder.AddAttribute(index++, "Variant", ButtonVariant.Plain);
            builder.AddAttribute(index++, "AriaLabel", CloseBtnAriaLabel);
            builder.AddAttribute(index++, "id", $"remove_{Id}");
            builder.AddAttribute(index++, "aria-labelledby", $"remove_{Id} {Id}");
            builder.AddAttribute(index++, "ChildContent", (RenderFragment)delegate(RenderTreeBuilder innerBuilder)
            {
                innerBuilder.OpenComponent<TimesIcon>(index++);
                innerBuilder.AddAttribute(index++, "aria-hidden", "true");
                innerBuilder.CloseComponent();
            });
            builder.CloseComponent();
        }

        builder.CloseElement();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            IsTooltipVisible = await DomUtils.HasTruncatedWidthAsync(Element);
            if (IsTooltipVisible)
            {
                StateHasChanged();
            }
        }
    }
}
